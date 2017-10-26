using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ExchangeDeclareOkFrame : MethodFrame<ExchangeDeclareOk>
    {
        internal ExchangeDeclareOkFrame(Int16 channel, ExchangeDeclareOk payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }
    }
}