using Autofac;
using Framework.Autofac.Boot.Autofac;
using Framework.Autofac.Boot.Logger;
using Framework.Autofac.Boot.Start;

namespace Framework.Autofac.Boot;

internal class BootModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule<AutofacModule>();
        builder.RegisterModule<StartModule>();
        builder.RegisterModule<LoggerModule>();

        base.Load(builder);
    }
}