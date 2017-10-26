using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ExchangeDeleteOkFrame : MethodFrame<ExchangeDeleteOk>
    {
        internal ExchangeDeleteOkFrame(Int16 channel, ExchangeDeleteOk payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }
    }
}