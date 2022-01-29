using Framework.DependencyInjection.Factory;
using Jab;

namespace Framework.Jab.Jab.Factory;

[ServiceProviderModule]
[Transient(typeof(IFactory), typeof(Factory))]
[Transient(typeof(IFactory<>), typeof(Factory<>))]
[Transient(typeof(IFactory<,>), typeof(Factory<,>))]
[Transient(typeof(IFactory<,,>), typeof(Factory<,,>))]
[Transient(typeof(IFactory<,,,>), typeof(Factory<,,,>))]
[Transient(typeof(IFactory<,,,,>), typeof(Factory<,,,,>))]
[Transient(typeof(IFactory<,,,,,>), typeof(Factory<,,,,,>))]
internal partial interface IFactoryModule
{
}