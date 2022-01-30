using Autofac;

namespace Framework.Autofac.Boot;

public interface IBootContext
{
    IList<Action<ContainerBuilder>> RegistrationActions { get; }
}