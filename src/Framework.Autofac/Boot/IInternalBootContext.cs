using Autofac;

namespace Framework.Autofac.Boot;

internal interface IInternalBootContext : IBootContext
{
    IContainer Container { get; }
    ILifetimeScope BootLifetimeScope { get; }
}