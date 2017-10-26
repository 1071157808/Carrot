using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class QueueUnbindOkFrame : MethodFrame<QueueUnbindOk>
    {
        internal QueueUnbindOkFrame(Int16 channelIndex, QueueUnbindOk payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}