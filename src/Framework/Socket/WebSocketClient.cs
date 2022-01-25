using System.Net.WebSockets;
using System.Text;

namespace Framework.Socket;

internal class WebSocketClient : IWebSocketClient
{
    public async Task<ClientWebSocket> ConnectAsync(Uri uri, CancellationToken cancellationToken)
    {
        var socket = new ClientWebSocket();
        await socket.ConnectAsync(uri, cancellationToken).ConfigureAwait(false);
        return socket;
    }

    public async Task ReceiveAsync(ClientWebSocket socket, Func<string, Task> callback, CancellationToken cancellationToken)
    {
        var message = await ReadMessageAsync(socket, cancellationToken).ConfigureAwait(false);
        if (!string.IsNullOrEmpty(message))
        {
            await callback(message).ConfigureAwait(false);
        }
    }

    private static async Task<string?> ReadMessageAsync(WebSocket socket, CancellationToken cancellationToken)
    {
        await using (var ms = new MemoryStream())
        {
            WebSocketReceiveResult result;
            var buffer = new ArraySegment<byte>(new byte[1024]);

            do
            {
                result = await socket.ReceiveAsync(buffer, cancellationToken).ConfigureAwait(false);
                await ms.WriteAsync((buffer.Array ?? Array.Empty<byte>())
                        .AsMemory(buffer.Offset, result.Count), cancellationToken)
                    .ConfigureAwait(false);
            } while (!result.EndOfMessage);

            ms.Seek(0, SeekOrigin.Begin);

            if (result.MessageType == WebSocketMessageType.Text)
            {
                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    return await reader.ReadToEndAsync().ConfigureAwait(false);
                }
            }

            if (result.MessageType == WebSocketMessageType.Close)
            {
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        return null;
    }
}