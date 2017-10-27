using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class BasicConsumeFrame : MethodFrame<BasicConsume>
    {
        internal BasicConsumeFrame(Int16 channelIndex, BasicConsume payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}