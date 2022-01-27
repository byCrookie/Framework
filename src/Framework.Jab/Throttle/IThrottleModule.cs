using Framework.Throttle;
using Jab;

namespace Framework.Jab.Throttle;

[ServiceProviderModule]
[Transient(typeof(ITaskThrottler), typeof(TaskThrottler))]
internal partial interface IThrottleModule
{
}