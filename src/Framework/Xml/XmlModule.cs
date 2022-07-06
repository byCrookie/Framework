using DependencyInjection.Microsoft.Modules;
using Framework.Time;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Xml;

public class XmlModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient<IXmlSerializer, XmlSerializer>();
        
        base.Load(services);
    }
}