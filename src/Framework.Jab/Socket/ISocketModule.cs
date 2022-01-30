using Framework.Socket;
using Jab;

namespace Framework.Jab.Socket;

[ServiceProviderModule]
[Transient(typeof(IWebSocketClient), typeof(WebSocketClient))]
internal interface ISocketModule
{
}