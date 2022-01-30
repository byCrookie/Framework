using Framework.Jab.Jab.Factory;
using Jab;

namespace Framework.Jab.Jab;

[ServiceProviderModule]
[Import(typeof(IFactoryModule))]
internal interface IJabModule
{
}