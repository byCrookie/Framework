using Autofac;
using Framework.Boot;
using Framework.Console.Test.Selection;

namespace Framework.Console.Test
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