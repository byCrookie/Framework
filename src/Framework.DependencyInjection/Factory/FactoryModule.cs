using Framework.DependencyInjection.Microsoft.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.DependencyInjection.Factory;

internal class FactoryModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient<IFactory, Factory>();
        services.AddTransient(typeof(IFactory<>), typeof(Factory<>));
        services.AddTransient(typeof(IFactory<,>), typeof(Factory<,>));
        services.AddTransient(typeof(IFactory<,,>), typeof(Factory<,,>));
        services.AddTransient(typeof(IFactory<,,,>), typeof(Factory<,,,>));
        services.AddTransient(typeof(IFactory<,,,,>), typeof(Factory<,,,,>));
        services.AddTransient(typeof(IFactory<,,,,,>), typeof(Factory<,,,,,>));

        base.Load(services);
    }
}