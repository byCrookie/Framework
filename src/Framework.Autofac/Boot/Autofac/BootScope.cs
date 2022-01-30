using JetBrains.Annotations;
using Workflow;

namespace Framework.Autofac.Boot.Autofac;

public class BootScope<T> where T : WorkflowBaseContext
{
    public BootScope(IWorkflowBuilder<T> workflowBuilder)
    {
        WorkflowBuilder = workflowBuilder;
    }
    
    [UsedImplicitly]
    public IWorkflowBuilder<T> WorkflowBuilder { get; }
}