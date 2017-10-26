using DotNetty.Buffers;
using Xunit;

namespace Carrot.Amqp.Tests
{
    public class Payloads
    {
        [Fact]
        public void ChannelClose()
        {
            var expected = new Amqp.Payloads.ChannelClose(1, "text", 1, 2);
            var buffer = Unpooled.Buffer();
            expected.Write(buffer);
            var actual = Amqp.Payloads.ChannelClose.Parse(buffer);
            Assert.Equal(expected.Descriptor, actual.Descriptor);
        }
    }
}