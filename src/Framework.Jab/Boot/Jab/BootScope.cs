using Workflow;

namespace Framework.Jab.Boot.Jab;

public class BootScope<T> : IInternalBootScope<T> where T : WorkflowBaseContext
{
    public BootScope(IServiceProvider serviceProvider, IWorkflowBuilder<T> workflowBuilder)
    {
        ServiceProvider = serviceProvider;
        WorkflowBuilder = workflowBuilder;
    }
    
    public IServiceProvider ServiceProvider { get; }
    public IWorkflowBuilder<T> WorkflowBuilder { get; }
}