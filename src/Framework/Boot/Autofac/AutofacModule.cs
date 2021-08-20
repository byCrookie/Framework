using Autofac;
using Framework.Boot.Autofac.BuildContainer;
using Framework.Boot.Autofac.ContainerBuilder;
using Framework.Boot.Autofac.ModuleCatalog;

namespace Framework.Boot.Autofac
{
    internal class AutofacModule : Module
    {
        protected override void Load(global::Autofac.ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ContainerBuildBootStep<>)).As(typeof(IContainerBuildBootStep<>));
            builder.RegisterGeneric(typeof(BuildContainerBootStep<>)).As(typeof(IBuildContainerBootStep<>));
            builder.RegisterGeneric(typeof(ModuleCatalogBootStep<>)).As(typeof(IModuleCatalogBootStep<>));
            
            base.Load(builder);
        }
    }
}