using Autofac;
using Framework.Boot;

namespace Framework.Console.Test
{
    public class FrameworkConsoleTestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Application>().As<IApplication>();
            
            base.Load(builder);
        }
    }
}