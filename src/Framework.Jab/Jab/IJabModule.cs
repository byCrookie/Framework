using Framework.Jab.Jab.Factory;
using Jab;

namespace Framework.Jab.Jab;

[ServiceProviderModule]
[Import(typeof(IFactoryModule))]
internal partial interface IJabModule
{
}