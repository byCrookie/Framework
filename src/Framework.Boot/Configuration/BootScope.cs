using Workflow;

namespace Framework.Boot.Configuration;

public class BootScope<T> : IInternalBootScope<T> where T : BootContext
{
    public BootScope(IServiceProvider serviceProvider, IWorkflowBuilder<T> workflowBuilder)
    {
        ServiceProvider = serviceProvider;
        WorkflowBuilder = workflowBuilder;
    }
    
    public IServiceProvider ServiceProvider { get; }
    public IWorkflowBuilder<T> WorkflowBuilder { get; }
}