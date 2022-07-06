using DependencyInjection.Microsoft.Modules;
using Framework.Hash;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Socket;

public class SocketModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient<IWebSocketClient, WebSocketClient>();
        
        base.Load(services);
    }
}