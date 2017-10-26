using DotNetty.Buffers;

namespace Carrot.Amqp.Frames
{
    internal interface IFrameParser
    {
        IFrame Parse(IByteBuffer buffer);
    }
}