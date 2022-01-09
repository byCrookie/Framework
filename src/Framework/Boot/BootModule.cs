using Autofac;
using Framework.Boot.Autofac;
using Framework.Boot.Logger;
using Framework.Boot.Start;

namespace Framework.Boot
{
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
}