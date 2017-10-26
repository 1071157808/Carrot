using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ChannelOpenOkFrame : MethodFrame<ChannelOpenOk>
    {
        internal ChannelOpenOkFrame(Int16 channel, ChannelOpenOk payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }
    }
}