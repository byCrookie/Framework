using Jab;

namespace Framework.Jab.Boot.Logger;

[ServiceProviderModule]
[Transient(typeof(ILoggerBootStep<,>), typeof(LoggerBootStep<,>))]
internal partial interface ILoggerModule
{
}