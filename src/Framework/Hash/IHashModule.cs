using Jab;

namespace Framework.Hash;

[ServiceProviderModule]
[Transient(typeof(IHashGenerator), typeof(HashGenerator))]
internal interface IHashModule
{
}