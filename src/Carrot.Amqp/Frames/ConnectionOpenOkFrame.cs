using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ConnectionOpenOkFrame : MethodFrame<ConnectionOpenOk>
    {
        internal ConnectionOpenOkFrame(Int16 channel, ConnectionOpenOk payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }
    }
}