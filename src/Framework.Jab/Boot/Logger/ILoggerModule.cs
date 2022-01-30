using Jab;

namespace Framework.Jab.Boot.Logger;

[ServiceProviderModule]
[Transient(typeof(ILoggerBootStep<BootContext, LoggerBootStepOptions>), typeof(LoggerBootStep<BootContext, LoggerBootStepOptions>))]
internal interface ILoggerModule
{
}