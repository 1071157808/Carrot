using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class QueueDeleteFrame : MethodFrame<QueueDelete>
    {
        internal QueueDeleteFrame(Int16 channelIndex, QueueDelete payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}