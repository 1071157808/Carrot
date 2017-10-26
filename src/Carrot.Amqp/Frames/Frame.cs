using System;
using System.Threading.Tasks;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal abstract class Frame<T> : IFrame
        where T : IFramePayload
    {
        public readonly T Payload;

        internal Frame(FrameHeader header, T payload)
        {
            Header = header;
            Payload = payload;
        }

        public FrameHeader Header { get; }

        IFramePayload IFrame.Payload => Payload;

        public abstract FrameType Type { get; }

        public abstract Task WriteToAsync(DotNetty.Transport.Channels.IChannel channel);

        public override String ToString()
        {
            return $"{{\"clr_type\":\"{GetType().Name}\",\"header\":{Header},\"payload\":{Payload}}}";
        }
    }
}