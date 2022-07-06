using DependencyInjection.Microsoft.Modules;
using Framework.EntityFramework.Access.Session;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.EntityFramework.Access;

internal class AccessModule : Module
{
    public override void Load(IServiceCollection services)
    {
        AddModule(new SessionModule());
        
        base.Load(services);
    }
}