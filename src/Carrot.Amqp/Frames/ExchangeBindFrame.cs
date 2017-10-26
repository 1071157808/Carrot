using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ExchangeBindFrame : MethodFrame<ExchangeBind>
    {
        internal ExchangeBindFrame(Int16 channelIndex, ExchangeBind payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}