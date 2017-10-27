using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class BasicConsumeOkFrame : MethodFrame<BasicConsumeOk>
    {
        internal BasicConsumeOkFrame(Int16 channelIndex, BasicConsumeOk payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}