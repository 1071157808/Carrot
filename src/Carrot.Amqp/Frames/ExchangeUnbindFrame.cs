using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ExchangeUnbindFrame : MethodFrame<ExchangeUnbind>
    {
        internal ExchangeUnbindFrame(Int16 channelIndex, ExchangeUnbind payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}