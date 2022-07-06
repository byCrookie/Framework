using DependencyInjection.Microsoft.Modules;
using Framework.Boot.Logger;
using Framework.Boot.Start;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Boot;

internal class BootModule : Module
{
    public override void Load(IServiceCollection services)
    {
        AddModule(new StartModule());
        AddModule(new LoggerModule());
        
        base.Load(services);
    }
}