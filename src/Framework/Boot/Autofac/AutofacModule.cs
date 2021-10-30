using Autofac;
using Framework.Boot.Autofac.ModuleCatalog;

namespace Framework.Boot.Autofac
{
    internal class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ModuleCatalogBootStep<>)).As(typeof(IModuleCatalogBootStep<>));

            base.Load(builder);
        }
    }
}