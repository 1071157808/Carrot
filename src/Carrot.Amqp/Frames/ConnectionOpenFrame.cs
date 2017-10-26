using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ConnectionOpenFrame : MethodFrame<ConnectionOpen>
    {
        internal ConnectionOpenFrame(Int16 channel, ConnectionOpen payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }
    }
}