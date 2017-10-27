﻿using System;
using Carrot.Amqp.Decoding;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Frames;
using Carrot.Amqp.Utils;
using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    internal class ExchangeBind : MethodFramePayload
    {
        internal static readonly MethodFrameDescriptor StaticDescriptor = new MethodFrameDescriptor(40, 30);

        internal readonly Int16 Reserved1;
        internal readonly String DestinationName;
        internal readonly String SourceName;
        internal readonly String RoutingKey;
        internal readonly Boolean NoWait;
        internal readonly Table Arguments;

        internal ExchangeBind(Int16 reserved1,
                              String destinationName,
                              String sourceName,
                              String routingKey,
                              Boolean noWait,
                              Table arguments) // TODO: arguments should be a bit less "generic"
        {
            Reserved1 = reserved1;

            ValidationUtils.ValidateExchangeName(destinationName);
            DestinationName = destinationName;

            ValidationUtils.ValidateExchangeName(sourceName);
            SourceName = sourceName;

            RoutingKey = routingKey;
            NoWait = noWait;
            Arguments = arguments;
        }

        internal static ExchangeBind Parse(IByteBuffer buffer)
        {
            var reserved1 = Int16FieldValueCodec.Instance.Decode(buffer);
            var destinationName = ShortStringFieldValueCodec.Instance.Decode(buffer);
            var sourceName = ShortStringFieldValueCodec.Instance.Decode(buffer);
            var routingKey = ShortStringFieldValueCodec.Instance.Decode(buffer);
            var b = (Int32)buffer.ReadByte();
            var noWait = (b & 1) == 1;

            var arguments = TableFieldValueCodec.Instance.Decode(buffer);

            return new ExchangeBind(reserved1,
                                    destinationName,
                                    sourceName,
                                    routingKey,
                                    noWait,
                                    arguments);
        }

        internal override MethodFrameDescriptor Descriptor => StaticDescriptor;

        protected override void WriteInternal(IByteBuffer buffer)
        {
            Int16FieldValueCodec.Instance.Encode(Reserved1, buffer);
            ShortStringFieldValueCodec.Instance.Encode(DestinationName, buffer);
            ShortStringFieldValueCodec.Instance.Encode(SourceName, buffer);
            ShortStringFieldValueCodec.Instance.Encode(RoutingKey, buffer);

            var b = 0;

            if (NoWait)
                b |= 1;

            buffer.WriteByte((Byte)b);

            TableFieldValueCodec.Instance.Encode(Arguments, buffer);
        }

        public override String ToString()
        {
            return $"{{\"descriptor\":{Descriptor},\"reserved_1\":{Reserved1},\"source_name\":\"{SourceName}\",\"destination_name\":\"{DestinationName}\",\"no_wait\":{NoWait.ToString().ToLowerInvariant()},\"arguments\":{Arguments}}}";
        }
    }
}