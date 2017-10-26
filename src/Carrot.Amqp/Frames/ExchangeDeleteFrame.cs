using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ExchangeDeleteFrame : MethodFrame<ExchangeDelete>
    {
        internal ExchangeDeleteFrame(Int16 channelIndex, ExchangeDelete payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}