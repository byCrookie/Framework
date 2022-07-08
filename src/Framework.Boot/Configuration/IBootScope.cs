using Workflow;

namespace Framework.Boot.Configuration;

public interface IBootScope<T> where T : BootContext
{
    IWorkflowBuilder<T> WorkflowBuilder { get; }
}