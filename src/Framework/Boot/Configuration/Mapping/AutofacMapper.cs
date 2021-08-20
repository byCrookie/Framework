namespace Framework.Boot.Configuration.Mapping
{
    internal class AutofacMapper : IAutofacMapper
    {
        public Autofac Map(XmlAutofac autofac)
        {
            return new()
            {
                AssemblySelctor = autofac.AssemblySelctor
            };
        }
    }
}