using Autofac;

namespace Framework.Autofac.Boot.Autofac;

internal interface IInternalBootScope<T> : IBootScope<T> where T : BootContext
{
    IContainer Container { get; }
    ILifetimeScope BootLifeTimeScope { get; }
}