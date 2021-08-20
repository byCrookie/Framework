using Autofac;
using Framework.Boot;
using Framework.Console.Tests.Selection;

namespace Framework.Console.Tests
{
    public class FrameworkConsoleTestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Application>().As<IApplication>();

            builder.RegisterModule<SelectionModule>();
            
            base.Load(builder);
        }
    }
}