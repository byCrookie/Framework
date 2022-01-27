using Framework.Time;
using Jab;

namespace Framework.Jab.Time;

[ServiceProviderModule]
[Transient(typeof(IDateTimeProvider), typeof(DateTimeProvider))]
internal partial interface ITimeModule
{
}