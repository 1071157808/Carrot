﻿using System;
using Carrot.Amqp.Decoding;
using Carrot.Amqp.Frames;
using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    internal class ConnectionOpen : MethodFramePayload
    {
        internal static readonly MethodFrameDescriptor StaticDescriptor = new MethodFrameDescriptor(10, 40);

        internal readonly String VirtualHost;
        internal readonly String Reserved1;
        internal readonly Boolean Reserved2;

        internal static ConnectionOpen Parse(IByteBuffer buffer)
        {
            var virtualHost = ShortStringFieldValueCodec.Instance.Decode(buffer);
            var reserved1 = ShortStringFieldValueCodec.Instance.Decode(buffer);
            var b = (Int32)buffer.ReadByte();
            var reserved2 = (b & 1) == 1;

            return new ConnectionOpen(virtualHost,
                                      reserved1,
                                      reserved2);
        }

        internal ConnectionOpen(String virtualHost, String reserved1 = "", Boolean reserved2 = false)
        {
            VirtualHost = virtualHost;
            Reserved1 = reserved1;
            Reserved2 = reserved2;
        }

        internal override MethodFrameDescriptor Descriptor => StaticDescriptor;

        protected override void WriteInternal(IByteBuffer buffer)
        {
            ShortStringFieldValueCodec.Instance.Encode(VirtualHost, buffer);
            ShortStringFieldValueCodec.Instance.Encode(Reserved1, buffer);

            var b = 0;

            if (Reserved2)
                b |= 1;

            buffer.WriteByte((Byte)b);
        }

        public override String ToString()
        {
            return $"{{\"descriptor\":{Descriptor},\"virtual_host\":\"{VirtualHost}\",\"reserved_1\":\"{Reserved1}\",\"reserved_2\":{Reserved2.ToString().ToLowerInvariant()}}}";
        }
    }
}