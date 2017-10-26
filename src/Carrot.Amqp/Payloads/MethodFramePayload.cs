﻿using System;
using Carrot.Amqp.Decoding;
using Carrot.Amqp.Frames;
using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    internal abstract class MethodFramePayload : IFramePayload
    {
        internal abstract MethodFrameDescriptor Descriptor { get; }

        public void Write(IByteBuffer buffer)
        {
            Int16FieldValueCodec.Instance.Encode(Descriptor.ClassId, buffer);
            Int16FieldValueCodec.Instance.Encode(Descriptor.MethodId, buffer);
            WriteInternal(buffer);
        }

        protected abstract void WriteInternal(IByteBuffer buffer);

        public override String ToString()
        {
            return $"{{\"descriptor\":{Descriptor}}}";
        }
    }
}