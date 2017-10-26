using System;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal class ConnectionStartOkFrame : MethodFrame<ConnectionStartOk>
    {
        internal ConnectionStartOkFrame(Int16 channel, ConnectionStartOk payload)
            : base(new FrameHeader(FrameType.METHOD, channel), payload)
        {
        }
    }
}