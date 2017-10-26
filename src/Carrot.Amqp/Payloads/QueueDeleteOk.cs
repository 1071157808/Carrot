using System;
using Carrot.Amqp.Decoding;
using Carrot.Amqp.Frames;
using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    internal class QueueDeleteOk : MethodFramePayload
    {
        internal static readonly MethodFrameDescriptor StaticDescriptor = new MethodFrameDescriptor(50, 41);

        internal readonly Int32 MessageCount;

        internal static QueueDeleteOk Parse(IByteBuffer buffer)
        {
            return new QueueDeleteOk(Int32FieldValueCodec.Instance.Decode(buffer));
        }

        internal QueueDeleteOk(Int32 messageCount)
        {
            MessageCount = messageCount;
        }

        internal override MethodFrameDescriptor Descriptor => StaticDescriptor;

        protected override void WriteInternal(IByteBuffer buffer)
        {
            Int32FieldValueCodec.Instance.Encode(MessageCount, buffer);
        }

        public override String ToString()
        {
            return $"{{\"descriptor\":{Descriptor},\"message_count\":{MessageCount}}}";
        }
    }
}