using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ChannelCloseOkFrame : MethodFrame<ChannelCloseOk>
    {
        internal ChannelCloseOkFrame(Int16 channel, ChannelCloseOk payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }
    }
}