using System;
using Carrot.Amqp.Frames;
using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    internal class BasicQosOk : MethodFramePayload
    {
        internal static readonly MethodFrameDescriptor StaticDescriptor = new MethodFrameDescriptor(60, 11);

        internal static BasicQosOk Parse(IByteBuffer buffer)
        {
            return new BasicQosOk();
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