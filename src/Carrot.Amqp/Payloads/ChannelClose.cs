﻿using System;
using Carrot.Amqp.Decoding;
using Carrot.Amqp.Frames;
using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    internal class ChannelClose : MethodFramePayload
    {
        internal static readonly MethodFrameDescriptor StaticDescriptor = new MethodFrameDescriptor(20, 40);

        internal readonly Int16 ReplyCode;
        internal readonly String ReplyText;
        internal readonly Int16 SourceClassId;
        internal readonly Int16 SourceMethodId;

        internal ChannelClose(Int16 replyCode,
                              String replyText,
                              Int16 sourceClassId,
                              Int16 sourceMethodId)
        {
            ReplyCode = replyCode;
            ReplyText = replyText;
            SourceClassId = sourceClassId;
            SourceMethodId = sourceMethodId;
        }

        internal static ChannelClose Parse(IByteBuffer buffer)
        {
            return new ChannelClose(Int16FieldValueCodec.Instance.Decode(buffer),
                                    ShortStringFieldValueCodec.Instance.Decode(buffer),
                                    Int16FieldValueCodec.Instance.Decode(buffer),
                                    Int16FieldValueCodec.Instance.Decode(buffer));
        }

        internal override MethodFrameDescriptor Descriptor => StaticDescriptor;

        protected override void WriteInternal(IByteBuffer buffer)
        {
            Int16FieldValueCodec.Instance.Encode(ReplyCode, buffer);
            ShortStringFieldValueCodec.Instance.Encode(ReplyText, buffer);
            Int16FieldValueCodec.Instance.Encode(SourceClassId, buffer);
            Int16FieldValueCodec.Instance.Encode(SourceMethodId, buffer);
        }

        public override String ToString()
        {
            return $"{{\"descriptor\":{Descriptor},\"reply_code\":{ReplyCode},\"reply_text\":\"{ReplyText}\",\"class_id\":{SourceClassId},\"method_id\":{SourceMethodId}}}";
        }
    }
}