using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class QueueDeclareOkFrame : MethodFrame<QueueDeclareOk>
    {
        internal QueueDeclareOkFrame(Int16 channel, QueueDeclareOk payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }
    }
}