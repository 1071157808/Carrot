using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ExchangeBindOkFrame : MethodFrame<ExchangeBindOk>
    {
        internal ExchangeBindOkFrame(Int16 channelIndex, ExchangeBindOk payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}