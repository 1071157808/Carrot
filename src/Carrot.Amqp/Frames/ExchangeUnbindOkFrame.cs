using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ExchangeUnbindOkFrame : MethodFrame<ExchangeUnbindOk>
    {
        internal ExchangeUnbindOkFrame(Int16 channelIndex, ExchangeUnbindOk payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}