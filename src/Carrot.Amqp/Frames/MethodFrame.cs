using System;
using System.Threading.Tasks;
using Carrot.Amqp.Entities;
using Carrot.Amqp.Payloads;
using DotNetty.Buffers;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;

namespace Carrot.Amqp.Frames
{
    internal class MethodFrame<T> : Frame<T>
        where T : MethodFramePayload
    {
        internal MethodFrame(FrameHeader header, T payload)
            : base(header, payload)
        {
        }

        public override Task WriteToAsync(DotNetty.Transport.Channels.IChannel channel)
        {
            var buffer = channel.Allocator.Buffer();
            buffer.WriteByte((Byte)Type);
            buffer.WriteShort(Header.ChannelIndex);

            // TODO: not sure about being the best strategy; looks expansive...
            var b = Unpooled.Buffer();
            Payload.Write(b);
            var array = b.ToArray();
            b.SafeRelease();

            buffer.WriteInt(array.Length);
            buffer.WriteBytes(array);
            buffer.WriteByte(0xCE);

            return channel.WriteAndFlushAsync(buffer);
        }

        public override FrameType Type => FrameType.METHOD;
    }
}