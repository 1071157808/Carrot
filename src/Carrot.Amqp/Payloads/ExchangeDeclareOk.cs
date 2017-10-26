using System;
using Carrot.Amqp.Frames;
using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    internal class ExchangeDeclareOk : MethodFramePayload
    {
        internal static readonly MethodFrameDescriptor StaticDescriptor = new MethodFrameDescriptor(40, 11);

        internal static ExchangeDeclareOk Parse(IByteBuffer buffer)
        {
            return new ExchangeDeclareOk();
        }

        internal override MethodFrameDescriptor Descriptor => StaticDescriptor;

        protected override void WriteInternal(IByteBuffer buffer)
        {
        }

        public override String ToString()
        {
            return $"{{\"descriptor\":{Descriptor}}}";
        }
    }
}