using Jab;
using Workflow;
using Workflow.Jab;

namespace Framework.Boot;

[ServiceProviderModule]
[Import(typeof(IBootModule))]
[Import(typeof(IWorkflowModule))]
[Transient(typeof(IWorkflowBuilder<BootContext>), typeof(WorkflowBuilder<BootContext>))]
public interface IFrameworkBootModule
{
    
}