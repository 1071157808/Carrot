using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ConnectionTuneOkFrame : MethodFrame<ConnectionTuneOk>
    {
        internal ConnectionTuneOkFrame(Int16 channel, ConnectionTuneOk payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }

        internal ConnectionOpenFrame ToConnectionOpenFrame(String virtualHost)
        {
            return new ConnectionOpenFrame(Header.ChannelIndex,
                                           new ConnectionOpen(virtualHost));
        }
    }
}