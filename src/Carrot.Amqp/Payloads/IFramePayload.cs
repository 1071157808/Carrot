using DotNetty.Buffers;

namespace Carrot.Amqp.Payloads
{
    public interface IFramePayload
    {
        void Write(IByteBuffer buffer);
    }
}