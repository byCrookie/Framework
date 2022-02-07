using Autofac;
using Workflow;

namespace Framework.Autofac.Boot.Autofac;

internal class BootScope<T> : IInternalBootScope<T> where T : BootContext
{
    public BootScope(IContainer container, ILifetimeScope bootLifeTimeScope, IWorkflowBuilder<T> workflowBuilder)
    {
        Container = container;
        BootLifeTimeScope = bootLifeTimeScope;
        WorkflowBuilder = workflowBuilder;
    }

    public IContainer Container { get; }
    public ILifetimeScope BootLifeTimeScope { get; }
    public IWorkflowBuilder<T> WorkflowBuilder { get; }
}