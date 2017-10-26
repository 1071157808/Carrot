using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ConnectionCloseFrame : MethodFrame<ConnectionClose>
    {
        internal static ConnectionCloseFrame Close()
        {
            return new ConnectionCloseFrame(0, new ConnectionClose(200, "connection_closed", 10, 51));
        }

        internal ConnectionCloseFrame(Int16 channel, ConnectionClose payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }
    }
}