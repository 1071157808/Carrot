using System;
using Carrot.Amqp.Frames;
using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    internal class QueueUnbindOk : MethodFramePayload
    {
        internal static readonly MethodFrameDescriptor StaticDescriptor = new MethodFrameDescriptor(50, 51);

        internal static QueueUnbindOk Parse(IByteBuffer buffer)
        {
            return new QueueUnbindOk();
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