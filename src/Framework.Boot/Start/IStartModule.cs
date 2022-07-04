using Jab;

namespace Framework.Boot.Start;

[ServiceProviderModule]
[Transient(typeof(IStartBootStep<>), typeof(StartBootStep<>))]
internal interface IStartModule
{
}