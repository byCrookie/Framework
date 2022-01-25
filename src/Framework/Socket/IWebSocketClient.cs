using System.Net.WebSockets;

namespace Framework.Socket;

public interface IWebSocketClient
{
    Task<ClientWebSocket> ConnectAsync(Uri uri, CancellationToken cancellationToken);
    Task ReceiveAsync(ClientWebSocket socket, Func<string, Task> callback, CancellationToken cancellationToken);
}