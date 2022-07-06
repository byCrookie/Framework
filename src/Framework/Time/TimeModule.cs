using DependencyInjection.Microsoft.Modules;
using Framework.Socket;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Time;

public class TimeModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        
        base.Load(services);
    }
}