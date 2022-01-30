using Autofac;
using Framework.Throttle;

namespace Framework.Autofac.Throttle;

internal class ThrottleModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TaskThrottler>().As<ITaskThrottler>();
            
        base.Load(builder);
    }
}