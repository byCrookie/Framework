using DependencyInjection.Microsoft.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Hash;

public class HashModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient<IHashGenerator, HashGenerator>();
        
        base.Load(services);
    }
}