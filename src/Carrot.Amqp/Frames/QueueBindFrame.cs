using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class QueueBindFrame : MethodFrame<QueueBind>
    {
        internal QueueBindFrame(Int16 channelIndex, QueueBind payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}