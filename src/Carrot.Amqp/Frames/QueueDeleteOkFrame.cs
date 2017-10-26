using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class QueueDeleteOkFrame : MethodFrame<QueueDeleteOk>
    {
        internal QueueDeleteOkFrame(Int16 channelIndex, QueueDeleteOk payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}