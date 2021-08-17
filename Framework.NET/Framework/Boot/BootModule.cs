using Autofac;
using Framework.Boot.AssemblyLoad;
using Framework.Boot.Autofac;
using Framework.Boot.Configuration;
using Framework.Boot.Logger;
using Framework.Boot.Start;
using Framework.Boot.TypeLoad;

namespace Framework.Boot
{
    internal class BootModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<AssemblyModule>();
            builder.RegisterModule<AutofacModule>();
            builder.RegisterModule<StartModule>();
            builder.RegisterModule<TypeModule>();
            builder.RegisterModule<LoggerModule>();
            builder.RegisterModule<ConfigurationModule>();
            
            base.Load(builder);
        }
    }
}