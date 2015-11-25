using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Carrot.Messages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Carrot
{
    public class OutboundChannel : IDisposable
    {
        private readonly IModel _model;

        private readonly ConcurrentDictionary<UInt64, Tuple<TaskCompletionSource<Boolean>, OutboundMessageEnvelope>> _confirms =
            new ConcurrentDictionary<UInt64, Tuple<TaskCompletionSource<Boolean>, OutboundMessageEnvelope>>();

        public OutboundChannel(IModel model)
        {
            _model = model;

            _model.BasicAcks += OnModelBasicAcks;
            _model.BasicNacks += OnModelBasicNacks;
            _model.ModelShutdown += OnModelShutdown;
        }

        public void Dispose()
        {
            if (_model == null)
                return;

            _model.WaitForConfirms(TimeSpan.FromSeconds(30d)); // TODO: timeout should not be hardcodeds

            _model.BasicAcks -= OnModelBasicAcks;
            _model.BasicNacks -= OnModelBasicNacks;
            _model.ModelShutdown -= OnModelShutdown;

            _model.Dispose();
        }

        internal OutboundMessageEnvelope BuildEnvelope(IBasicProperties properties,
                                                       Byte[] body,
                                                       Exchange exchange,
                                                       String routingKey)
        {
            var tag = _model.NextPublishSeqNo;
            return new OutboundMessageEnvelope(properties, body, exchange, routingKey, tag);
        }

        internal Task<IPublishResult> PublishAsync(OutboundMessageEnvelope message)
        {
            var tcs = new TaskCompletionSource<Boolean>(message.Properties);
            _confirms.TryAdd(message.Tag,
                             new Tuple<TaskCompletionSource<Boolean>, OutboundMessageEnvelope>(tcs, message));

            try
            {
                _model.BasicPublish(message.Exchange.Name,
                                    message.RoutingKey,
                                    false,
                                    false,
                                    message.Properties,
                                    message.Body);
            }
            catch (Exception exception)
            {
                Tuple<TaskCompletionSource<Boolean>, OutboundMessageEnvelope> tuple;
                _confirms.TryRemove(message.Tag, out tuple);
                tcs.TrySetException(exception);
            }

            return tcs.Task.ContinueWith(Result);
        }

        protected virtual void OnModelBasicNacks(Object sender, BasicNackEventArgs args)
        {
            HandleServerResponse(args.DeliveryTag,
                                 args.Multiple,
                                 _ => _.TrySetException(new InvalidOperationException("publish was NACK-ed")));
        }

        protected virtual void OnModelBasicAcks(Object sender, BasicAckEventArgs args)
        {
            HandleServerResponse(args.DeliveryTag,
                                 args.Multiple,
                                 _ => _.TrySetResult(true));
        }

        protected virtual void OnModelShutdown(Object sender, ShutdownEventArgs args)
        {
            foreach (var confirm in _confirms)
            {
                var exception = new MessageNotConfirmedException(confirm.Value.Item2,
                                                                 "publish not confirmed before channel closed");
                confirm.Value.Item1.TrySetException(exception);
            }
        }

        private static IPublishResult Result(Task task)
        {
            if (task.Exception != null)
                return new FailurePublishing(task.Exception.GetBaseException());

            return SuccessfulPublishing.FromBasicProperties(task.AsyncState as IBasicProperties);
        }

        private void HandleServerResponse(UInt64 deliveryTag,
                                          Boolean multiple,
                                          Action<TaskCompletionSource<Boolean>> action)
        {
            var tags = multiple
                ? _confirms.Keys.Where(_ => _ <= deliveryTag)
                : Enumerable.Repeat(deliveryTag, 1);

            foreach (var tag in tags)
            {
                action(_confirms[tag].Item1);
                Tuple<TaskCompletionSource<Boolean>, OutboundMessageEnvelope> tuple;
                _confirms.TryRemove(tag, out tuple);
            }
        }
    }

    public class MessageNotConfirmedException : Exception
    {
        internal MessageNotConfirmedException(OutboundMessageEnvelope envelope, String message)
            : base(message)
        {
            Envelope = envelope;
        }

        public OutboundMessageEnvelope Envelope { get; }
    }
}