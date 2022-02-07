using JetBrains.Annotations;
using Workflow;

namespace Framework.Jab.Boot.Jab;

public interface IBootScope<T> where T : BootContext
{
    [UsedImplicitly]
    IWorkflowBuilder<T> WorkflowBuilder { get; }
}