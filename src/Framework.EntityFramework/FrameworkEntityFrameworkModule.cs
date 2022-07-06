using DependencyInjection.Microsoft.Modules;
using Framework.EntityFramework.Access;
using Framework.EntityFramework.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.EntityFramework;

public class FrameworkEntityFrameworkModule : Module
{
    public override void Load(IServiceCollection services)
    {
        AddModule(new AccessModule());
        AddModule(new MappingModule());
        
        base.Load(services);
    }
}