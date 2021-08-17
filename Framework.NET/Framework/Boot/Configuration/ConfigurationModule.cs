using Autofac;
using Framework.Boot.Configuration.Mapping;

namespace Framework.Boot.Configuration
{
    internal class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FrameworkConfigurationMapper>().As<IFrameworkConfigurationMapper>();
            builder.RegisterType<FrameworkMapper>().As<IFrameworkMapper>();
            builder.RegisterType<AutofacMapper>().As<IAutofacMapper>();
            
            builder.RegisterGeneric(typeof(FrameworkConfigurationBootStep<,>)).As(typeof(IFrameworkConfigurationBootStep<,>));
            
            base.Load(builder);
        }
    }
}