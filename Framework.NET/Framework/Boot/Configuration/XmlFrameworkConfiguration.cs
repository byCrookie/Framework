using System.Collections.Generic;
using System.Xml.Serialization;

namespace Framework.Boot.Configuration
{
    [XmlRoot(ElementName="autofac")]
    internal class XmlAutofac {
        [XmlElement(ElementName="assemblySelctor")] 
        public List<string> AssemblySelctor { get; set; }
    }

    [XmlRoot(ElementName="framework")]
    internal class XmlFramework {
        [XmlElement(ElementName="autofac")] 
        public XmlAutofac Autofac { get; set; }
    }

    [XmlRoot(ElementName="configuration")]
    internal class XmlFrameworkConfiguration {
        [XmlElement(ElementName="framework")] 
        public XmlFramework Framework { get; set; }
    }
}