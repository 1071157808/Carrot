using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ChannelCloseFrame : MethodFrame<ChannelClose>
    {
        internal static ChannelCloseFrame Close(Int16 channelIndex)
        {
            return new ChannelCloseFrame(channelIndex,
                                         new ChannelClose(200,
                                                          "connection_closed",
                                                          20,
                                                          41));
        }

        internal ChannelCloseFrame(Int16 channel, ChannelClose payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }
    }
}