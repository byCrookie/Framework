using Framework.Boot.Logger;
using Framework.Boot.Start;
using Jab;

namespace Framework.Boot;

[ServiceProviderModule]
[Import(typeof(IStartModule))]
[Import(typeof(ILoggerModule))]
internal interface IBootModule
{
}