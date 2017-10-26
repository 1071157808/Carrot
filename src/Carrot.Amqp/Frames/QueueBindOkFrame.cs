using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class QueueBindOkFrame : MethodFrame<QueueBindOk>
    {
        internal QueueBindOkFrame(Int16 channelIndex, QueueBindOk payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}