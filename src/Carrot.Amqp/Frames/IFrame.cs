using System.Threading.Tasks;
using Carrot.Amqp.Payloads;

namespace Carrot.Amqp.Frames
{
    internal interface IFrame
    {
        FrameHeader Header { get; }

        IFramePayload Payload { get; }

        Task WriteToAsync(DotNetty.Transport.Channels.IChannel channel);
    }
}