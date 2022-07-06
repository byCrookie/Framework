using DependencyInjection.Microsoft.Modules;
using Microsoft.Extensions.DependencyInjection;
using Workflow;
using Workflow.DependencyInjection;

namespace Framework.Boot;

public class FrameworkBootModule : Module
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient(typeof(IWorkflowBuilder<BootContext>), typeof(WorkflowBuilder<BootContext>));
        
        AddModule(new BootModule());
        AddModule(new WorkflowModule());
        
        base.Load(services);
    }
}