using Framework.Hash;
using Framework.Socket;
using Framework.Time;
using Framework.Xml;
using Jab;

namespace Framework;

[ServiceProviderModule]
[Import(typeof(IXmlModule))]
[Import(typeof(ISocketModule))]
[Import(typeof(IHashModule))]
[Import(typeof(ITimeModule))]
public interface IFrameworkModule
{
}