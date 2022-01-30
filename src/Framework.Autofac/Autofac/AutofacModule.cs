using Autofac;
using Framework.Autofac.Autofac.Factory;

namespace Framework.Autofac.Autofac;

internal class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule<FactoryModule>();
            
        base.Load(builder);
    }
}