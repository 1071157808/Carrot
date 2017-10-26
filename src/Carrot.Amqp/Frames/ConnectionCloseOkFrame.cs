using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ConnectionCloseOkFrame : MethodFrame<ConnectionCloseOk>
    {
        internal ConnectionCloseOkFrame(Int16 channel, ConnectionCloseOk payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }
    }
}