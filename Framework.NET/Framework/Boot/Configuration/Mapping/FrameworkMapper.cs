namespace Framework.Boot.Configuration.Mapping
{
    internal class FrameworkMapper : IFrameworkMapper
    {
        private readonly IAutofacMapper _autofacMapper;

        public FrameworkMapper(IAutofacMapper autofacMapper)
        {
            _autofacMapper = autofacMapper;
        }

        public Framework Map(XmlFramework framework)
        {
            return new()
            {
                Autofac = _autofacMapper.Map(framework.Autofac)
            };
        }
    }
}