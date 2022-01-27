using Framework.Timer;
using Jab;

namespace Framework.Jab.Timer;

[ServiceProviderModule]
[Transient(typeof(IIntervalTimer), typeof(IntervalTimer))]
internal partial interface ITimerModule
{
}