using Jab;

namespace Framework.Xml;

[ServiceProviderModule]
[Transient(typeof(IXmlSerializer), typeof(XmlSerializer))]
internal interface IXmlModule
{
}