using Jab;

namespace Framework.Time;

[ServiceProviderModule]
[Transient(typeof(IDateTimeProvider), typeof(DateTimeProvider))]
internal interface ITimeModule
{
}