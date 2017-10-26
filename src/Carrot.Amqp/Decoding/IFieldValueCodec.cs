using System;
using DotNetty.Buffers;

namespace Carrot.Amqp.Decoding
{
    internal interface IFieldValueCodec
    {
        Object Decode(IByteBuffer buffer);

        void Encode(Object source, IByteBuffer destination);

        Byte Type { get; }
    }
}