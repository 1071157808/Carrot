using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class QueueDeclareFrame : MethodFrame<QueueDeclare>
    {
        internal QueueDeclareFrame(Int16 channelIndex, QueueDeclare payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}