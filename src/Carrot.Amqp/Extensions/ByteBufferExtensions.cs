using System;
using Carrot.Amqp.Decoding;
using DotNetty.Buffers;

namespace Carrot.Amqp.Extensions
{
    internal static class ByteBufferExtensions
    {
        internal static String DecodeFieldName(this IByteBuffer buffer)
        {
            return ShortStringFieldValueCodec.Instance.Decode(buffer);
        }

        internal static void EncodeFieldName(this String source, IByteBuffer buffer)
        {
            ShortStringFieldValueCodec.Instance.Encode(source, buffer);
        }
    }
}