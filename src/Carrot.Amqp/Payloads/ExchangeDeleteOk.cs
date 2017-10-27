﻿using System;
using Carrot.Amqp.Frames;
using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    internal class ExchangeDeleteOk : MethodFramePayload
    {
        internal static readonly MethodFrameDescriptor StaticDescriptor = new MethodFrameDescriptor(40, 21);

        internal static ExchangeDeleteOk Parse(IByteBuffer buffer)
        {
            return new ExchangeDeleteOk();
        }

        internal override MethodFrameDescriptor Descriptor => StaticDescriptor;

        protected override void WriteInternal(IByteBuffer buffer)
        {
        }

        public override String ToString()
        {
            return $"{{\"descriptor\":{Descriptor}}}";
        }
    }
}