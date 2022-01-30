using Autofac;

namespace Framework.Autofac.Boot;

public interface IBootContext
{
    IContainer Container { get; set; }
    IList<Action<ContainerBuilder>> RegistrationActions { get; set; }
    ILifetimeScope BootLifetimeScope { get; set; }
    ILifetimeScope? LifetimeScope { get; set; }
}