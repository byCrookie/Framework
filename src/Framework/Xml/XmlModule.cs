using Autofac;

namespace Framework.Xml;

internal class XmlModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<XmlSerializer>().As<IXmlSerializer>();
            
        base.Load(builder);
    }
}