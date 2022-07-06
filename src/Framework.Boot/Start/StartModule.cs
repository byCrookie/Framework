using DependencyInjection.Microsoft.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Boot.Start;

internal class StartModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient(typeof(IStartBootStep<>), typeof(StartBootStep<>));
        
        base.Load(services);
    }
}