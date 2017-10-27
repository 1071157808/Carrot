using System;
using Carrot.Amqp.Decoding;
using Carrot.Amqp.Frames;
using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    internal class BasicConsumeOk : MethodFramePayload
    {
        internal static readonly MethodFrameDescriptor StaticDescriptor = new MethodFrameDescriptor(60, 21);

        internal readonly String ConsumerTag;
        internal BasicConsumeOk(String consumerTag)
        {
            ConsumerTag = consumerTag;
        }

        internal static BasicConsumeOk Parse(IByteBuffer buffer)
        {
            return new BasicConsumeOk(ShortStringFieldValueCodec.Instance.Decode(buffer));
        }

        internal override MethodFrameDescriptor Descriptor => StaticDescriptor;

        protected override void WriteInternal(IByteBuffer buffer)
        {
            ShortStringFieldValueCodec.Instance.Encode(ConsumerTag, buffer);
        }

        public override String ToString()
        {
            return $"{{\"descriptor\":{Descriptor},\"consumer_tag\":\"{ConsumerTag}\"}}";
        }
    }
}