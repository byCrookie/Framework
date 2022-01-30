using Autofac;
using Framework.Autofac.Boot.Autofac;
using JetBrains.Annotations;
using Workflow;

namespace Framework.Autofac.Boot;

[UsedImplicitly]
public class BootContext : WorkflowBaseContext, IInternalBootContext
{
    public BootContext(IBootScope<BootContext> bootScope)
    {
        if (bootScope is not IInternalBootScope<BootContext> internalBootScope)
        {
            throw new ArgumentException($"{nameof(bootScope)} does not implement {typeof(IInternalBootScope<BootContext>).FullName}");
        }

        Container = internalBootScope.Container;
        BootLifetimeScope = internalBootScope.BootLifeTimeScope;

        RegistrationActions = new List<Action<ContainerBuilder>>();
    }

    public IContainer Container { get; }
    public ILifetimeScope BootLifetimeScope { get; }
    public IList<Action<ContainerBuilder>> RegistrationActions { get; }
}