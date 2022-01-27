using Autofac;
using Framework.Timer;

namespace Framework.Autofac.Timer;

internal class TimerModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<IntervalTimer>().As<IIntervalTimer>();
            
        base.Load(builder);
    }
}