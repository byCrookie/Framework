using Workflow;

namespace Framework.Jab.Boot.Jab;

public class BootScope<T> where T : WorkflowBaseContext
{
    public BootScope(IWorkflowBuilder<T>? workflowBuilder, IServiceProvider serviceProvider)
    {
        WorkflowBuilder = workflowBuilder;
        ServiceProvider = serviceProvider;
    }

    public IWorkflowBuilder<T>? WorkflowBuilder { get; }
    public IServiceProvider ServiceProvider { get; }
}