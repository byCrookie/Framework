﻿using Autofac;
using Framework.Socket;

namespace Framework.Autofac.Socket;

internal class SocketModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<WebSocketClient>().As<IWebSocketClient>();
            
        base.Load(builder);
    }
}