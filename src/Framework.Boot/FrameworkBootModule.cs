using DependencyInjection.Microsoft.Modules;
using Microsoft.Extensions.DependencyInjection;
using Workflow.DependencyInjection;

namespace Framework.Boot;

public class FrameworkBootModule : Module
{
    public override void Load(IServiceCollection services)
    {
        AddModule(new BootModule());
        AddModule(new WorkflowModule());
        
        base.Load(services);
    }
}