using DependencyInjection.Microsoft.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.EntityFramework.Mapping;

internal class MappingModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient(typeof(IDataEntityMapper<,>), typeof(DataEntityMapper<,>));
        
        base.Load(services);
    }
}