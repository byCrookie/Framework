using JetBrains.Annotations;
using Workflow;

namespace Framework.Jab.Boot.Jab;

public interface IBootScope<T> where T : WorkflowBaseContext
{
    [UsedImplicitly]
    IWorkflowBuilder<T> WorkflowBuilder { get; }
}