using System;
using System.Threading.Tasks;
using Carrot.Messaging;

namespace Carrot.Messages
{
    public abstract class ConsumedMessageBase
    {
        protected readonly String MessageId;
        protected readonly UInt64 DeliveryTag;
        protected readonly Boolean Redelivered;

        protected ConsumedMessageBase(String messageId, UInt64 deliveryTag, Boolean redelivered)
        {
            MessageId = messageId;
            DeliveryTag = deliveryTag;
            Redelivered = redelivered;
        }

        internal abstract Object Content { get; }

        internal abstract Task<IAggregateConsumingResult> ConsumeAsync(SubscriptionConfiguration configuration);

        internal Message<TMessage> As<TMessage>() where TMessage : class
        {
            var content = Content as TMessage;

            // TODO: check is proper type.

            return new Message<TMessage>(content, FillHeaders<TMessage>());
        }

        private Message<TMessage>.HeaderCollection FillHeaders<TMessage>() where TMessage : class
        {
            return new Message<TMessage>.HeaderCollection
                       {
                           { "message_id", MessageId }
                       };
        }

        internal abstract Boolean Match(Type type);
    }
}