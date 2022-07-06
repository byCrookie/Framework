using DependencyInjection.Microsoft.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Boot.Logger;

internal class LoggerModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient(typeof(ILoggerBootStep<BootContext, LoggerBootStepOptions>), typeof(LoggerBootStep<BootContext, LoggerBootStepOptions>));
        
        base.Load(services);
    }
}