using JetBrains.Annotations;
using Workflow;

namespace Framework.Autofac.Boot.Autofac;

public interface IBootScope<T> where T : BootContext
{
    [UsedImplicitly]
    IWorkflowBuilder<T> WorkflowBuilder { get; }
}