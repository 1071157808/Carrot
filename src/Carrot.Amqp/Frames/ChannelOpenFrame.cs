using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ChannelOpenFrame : MethodFrame<ChannelOpen>
    {
        internal ChannelOpenFrame(Int16 channel, ChannelOpen payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }
    }
}