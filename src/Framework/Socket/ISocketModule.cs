using Jab;

namespace Framework.Socket;

[ServiceProviderModule]
[Transient(typeof(IWebSocketClient), typeof(WebSocketClient))]
internal interface ISocketModule
{
}