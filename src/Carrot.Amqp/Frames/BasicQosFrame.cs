using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class BasicQosFrame : MethodFrame<BasicQos>
    {
        internal BasicQosFrame(Int16 channelIndex, BasicQos payload)
            : base(new FrameHeader(FrameType.METHOD, channelIndex), payload)
        {
        }
    }
}