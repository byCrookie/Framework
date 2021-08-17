namespace Framework.Boot.Configuration.Mapping
{
    internal class FrameworkConfigurationMapper : IFrameworkConfigurationMapper
    {
        private readonly IFrameworkMapper _frameworkMapper;

        public FrameworkConfigurationMapper(IFrameworkMapper frameworkMapper)
        {
            _frameworkMapper = frameworkMapper;
        }

        public FrameworkConfiguration Map(XmlFrameworkConfiguration xmlFrameworkConfiguration)
        {
            return new()
            {
                Framework = _frameworkMapper.Map(xmlFrameworkConfiguration.Framework)
            };
        }
    }
}