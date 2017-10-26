using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ConnectionTuneFrame : MethodFrame<ConnectionTune>
    {
        internal ConnectionTuneFrame(Int16 channel, ConnectionTune payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }

        internal ConnectionTuneOkFrame ToConnectionTuneOkFrame()
        {
            return new ConnectionTuneOkFrame(Header.ChannelIndex,
                                             new ConnectionTuneOk(Payload.ChannelMax,
                                                                  Payload.FrameMax,
                                                                  Payload.Heartbeat));
        }
    }
}