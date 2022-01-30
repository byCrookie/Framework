using JetBrains.Annotations;
using Workflow;

namespace Framework.Autofac.Boot.Autofac;

public interface IBootScope<T> where T : WorkflowBaseContext
{
    [UsedImplicitly]
    IWorkflowBuilder<T> WorkflowBuilder { get; }
}