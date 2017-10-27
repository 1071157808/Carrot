﻿using System;
using Carrot.Amqp.Decoding;
using Carrot.Amqp.Frames;
using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    internal class ChannelOpen : MethodFramePayload
    {
        internal static readonly MethodFrameDescriptor StaticDescriptor = new MethodFrameDescriptor(20, 10);

        internal readonly String Reserved1;

        internal ChannelOpen(String reserved1 = "")
        {
            Reserved1 = reserved1;
        }

        internal static ChannelOpen Parse(IByteBuffer buffer)
        {
            return new ChannelOpen(ShortStringFieldValueCodec.Instance.Decode(buffer));
        }

        internal override MethodFrameDescriptor Descriptor => StaticDescriptor;

        protected override void WriteInternal(IByteBuffer buffer)
        {
            ShortStringFieldValueCodec.Instance.Encode(Reserved1, buffer);
        }

        public override String ToString()
        {
            return $"{{\"descriptor\":{Descriptor},\"reserved_1\":\"{Reserved1}\"}}";
        }
    }
}