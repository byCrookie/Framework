using Autofac;
using Framework.Boot.Autofac.BeginLifeTimeScope;
using Framework.Boot.Autofac.DisposeBootLifeTimeScope;
using Framework.Boot.Autofac.ModuleCatalog;

namespace Framework.Boot.Autofac
{
    internal class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BeginLifeTimeScopeBootStep<>)).As(typeof(IBeginLifeTimeScopeBootStep<>));
            builder.RegisterGeneric(typeof(ModuleCatalogBootStep<>)).As(typeof(IModuleCatalogBootStep<>));
            builder.RegisterGeneric(typeof(DisposeBootLifeTimeScopeStepStep<>)).As(typeof(IDisposeBootLifeTimeScopeStep<>));
            
            base.Load(builder);
        }
    }
}