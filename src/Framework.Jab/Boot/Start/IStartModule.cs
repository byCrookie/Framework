using Jab;

namespace Framework.Jab.Boot.Start;

[ServiceProviderModule]
[Transient(typeof(IStartBootStep<>), typeof(StartBootStep<>))]
internal partial interface IStartModule
{
}