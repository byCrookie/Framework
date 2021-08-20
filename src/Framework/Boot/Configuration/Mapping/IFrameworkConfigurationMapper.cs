namespace Framework.Boot.Configuration.Mapping
{
    internal interface IFrameworkConfigurationMapper
    {
        FrameworkConfiguration Map(XmlFrameworkConfiguration xmlFrameworkConfiguration);
    }
}