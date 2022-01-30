using Jab;

namespace Framework.Jab.Boot.Logger;

[ServiceProviderModule]
[Transient(typeof(ILoggerBootStep<,>), typeof(LoggerBootStep<,>))]
internal interface ILoggerModule
{
}