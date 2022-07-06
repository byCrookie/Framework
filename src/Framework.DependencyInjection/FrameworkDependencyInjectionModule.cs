using Framework.DependencyInjection.Factory;
using Framework.DependencyInjection.Microsoft.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.DependencyInjection;

public class FrameworkDependencyInjectionModule : Module
{
    public override void Load(IServiceCollection services)
    {
        AddModule(new FactoryModule());
        
        base.Load(services);
    }
}