using System;
using System.Threading.Tasks;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal abstract class Frame<T> : IFrame
        where T : class, IFramePayload
    {
        public readonly T Payload;

        internal Frame(FrameHeader header, T payload)
        {
            Header = header;
            Payload = payload;
        }

        public FrameHeader Header { get; }

        IFramePayload IFrame.Payload => Payload;

        public abstract Task WriteToAsync(DotNetty.Transport.Channels.IChannel channel);

        public override String ToString()
        {
            return $"{{\"clr_type\":\"{GetType().Name}\",\"header\":{Header},\"payload\":{Payload}}}";
        }
    }
}