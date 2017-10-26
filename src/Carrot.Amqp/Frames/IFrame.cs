using System.Threading.Tasks;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;
using DotNetty.Transport.Channels;

namespace Carrot.Amqp.Frames
{
    internal interface IFrame
    {
        FrameHeader Header { get; }

        IFramePayload Payload { get; }

        FrameType Type { get; }

        Task WriteToAsync(DotNetty.Transport.Channels.IChannel channel);
    }
}