using System;
using Carrot.Amqp.Frames;
using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    internal class ExchangeBindOk : MethodFramePayload
    {
        internal static readonly MethodFrameDescriptor StaticDescriptor = new MethodFrameDescriptor(40, 31);

        internal static ExchangeBindOk Parse(IByteBuffer buffer)
        {
            return new ExchangeBindOk();
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