using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class QueueUnbindFrame : MethodFrame<QueueUnbind>
    {
        internal QueueUnbindFrame(Int16 channelIndex, QueueUnbind payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}