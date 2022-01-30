using Framework.Hash;
using Jab;

namespace Framework.Jab.Hash;

[ServiceProviderModule]
[Transient(typeof(IHashGenerator), typeof(HashGenerator))]
internal interface IHashModule
{
}