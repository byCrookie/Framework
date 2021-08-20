using Autofac;
using Framework.Autofac.Factory;

namespace Framework.Autofac
{
    internal class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<FactoryModule>();
            
            base.Load(builder);
        }
    }
}