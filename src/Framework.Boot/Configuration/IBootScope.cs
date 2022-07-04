using JetBrains.Annotations;
using Workflow;

namespace Framework.Boot.Configuration;

public interface IBootScope<T> where T : BootContext
{
    [UsedImplicitly]
    IWorkflowBuilder<T> WorkflowBuilder { get; }
}