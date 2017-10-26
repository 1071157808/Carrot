using System;
using Carrot.Amqp.Decoding;
using Carrot.Amqp.Frames;
using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    internal class ChannelOpenOk : MethodFramePayload
    {
        internal static readonly MethodFrameDescriptor StaticDescriptor = new MethodFrameDescriptor(20, 11);

        internal readonly String Reserved1;

        internal static ChannelOpenOk Parse(IByteBuffer buffer)
        {
            return new ChannelOpenOk(LongStringFieldValueCodec.Instance.Decode(buffer));
        }

        internal ChannelOpenOk(String reserved1 = "")
        {
            Reserved1 = reserved1;
        }

        internal override MethodFrameDescriptor Descriptor => StaticDescriptor;

        protected override void WriteInternal(IByteBuffer buffer)
        {
            LongStringFieldValueCodec.Instance.Encode(Reserved1, buffer);
        }

        public override String ToString()
        {
            return $"{{\"descriptor\":{Descriptor},\"reserved_1\":\"{Reserved1}\"}}";
        }
    }
}