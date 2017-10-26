using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ExchangeDeclareFrame : MethodFrame<ExchangeDeclare>
    {
        internal ExchangeDeclareFrame(Int16 channelIndex, ExchangeDeclare payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}