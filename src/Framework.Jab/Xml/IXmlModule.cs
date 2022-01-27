using Framework.Xml;
using Jab;
using XmlSerializer = Framework.Xml.XmlSerializer;

namespace Framework.Jab.Xml;

[ServiceProviderModule]
[Transient(typeof(IXmlSerializer), typeof(XmlSerializer))]
internal partial interface IXmlModule
{
}