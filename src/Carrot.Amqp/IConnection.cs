using System;
using System.Threading.Tasks;

namespace Carrot.Amqp
{
    public interface IConnection : IDisposable
    {
        Task<IChannel> OpenChannelAsync();

        Task CloseAsync();
    }
}