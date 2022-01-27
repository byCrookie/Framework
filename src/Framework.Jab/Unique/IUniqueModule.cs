using Framework.Unique;
using Jab;

namespace Framework.Jab.Unique;

[ServiceProviderModule]
[Transient(typeof(IUniqueGenerator), typeof(UniqueGenerator))]
internal partial interface IUniqueModule
{
}