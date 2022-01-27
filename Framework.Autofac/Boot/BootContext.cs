using Autofac;
using Workflow;

namespace Framework.Autofac.Boot;

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
    public ILifetimeScope? LifetimeScope { get; set; }
}