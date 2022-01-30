using Framework.Jab.Boot.Logger;
using Framework.Jab.Boot.Start;
using Jab;

namespace Framework.Jab.Boot;

[ServiceProviderModule]
[Import(typeof(IStartModule))]
[Import(typeof(ILoggerModule))]
internal interface IBootModule
{
}