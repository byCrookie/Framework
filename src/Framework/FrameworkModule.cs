using DependencyInjection.Microsoft.Modules;
using Framework.Hash;
using Framework.Socket;
using Framework.Time;
using Framework.Xml;
using Microsoft.Extensions.DependencyInjection;

namespace Framework;

public class FrameworkModule : Module
{
    public override void Load(IServiceCollection services)
    {
        AddModule(new XmlModule());
        AddModule(new SocketModule());
        AddModule(new HashModule());
        AddModule(new TimeModule());
        
        base.Load(services);
    }
}