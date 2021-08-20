using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Socket
{
    public interface IWebSocketClient
    {
        Task<ClientWebSocket> ConnectAsync(Uri uri, CancellationToken cancellationToken);
        Task ReceiveAsync(ClientWebSocket socket, Func<string, Task> callback, CancellationToken cancellationToken);
    }
}