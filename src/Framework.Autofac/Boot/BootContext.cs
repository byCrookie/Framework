using Autofac;
using JetBrains.Annotations;
using Workflow;

namespace Framework.Autofac.Boot;

[UsedImplicitly]
public class BootContext : WorkflowBaseContext, IBootContext
{
    public BootContext(IContainer container, ILifetimeScope bootLifetimeScope)
    {
        Container = container;
        BootLifetimeScope = bootLifetimeScope;
            
        RegistrationActions = new List<Action<ContainerBuilder>>();
    }
        
    public IContainer Container { get; set; }
    public IList<Action<ContainerBuilder>> RegistrationActions { get; set; }
    public ILifetimeScope BootLifetimeScope { get; set; }
}