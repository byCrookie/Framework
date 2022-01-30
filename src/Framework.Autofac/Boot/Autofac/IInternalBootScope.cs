using Autofac;
using Workflow;

namespace Framework.Autofac.Boot.Autofac;

internal interface IInternalBootScope<T> : IBootScope<T> where T : WorkflowBaseContext
{
    IContainer Container { get; }
    ILifetimeScope BootLifeTimeScope { get; }
}