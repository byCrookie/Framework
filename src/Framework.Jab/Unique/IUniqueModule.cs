using Framework.Unique;
using Jab;

namespace Framework.Jab.Unique;

[ServiceProviderModule]
[Transient(typeof(IUniqueGenerator), typeof(UniqueGenerator))]
public partial interface IUniqueModule
{
}