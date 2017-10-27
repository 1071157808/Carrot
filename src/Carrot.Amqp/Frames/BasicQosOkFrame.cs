using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class BasicQosOkFrame : MethodFrame<BasicQosOk>
    {
        internal BasicQosOkFrame(Int16 channelIndex, BasicQosOk payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}