using Autofac;

namespace Framework.Timer;

internal class TimerModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<IntervalTimer>().As<IIntervalTimer>();
            
        base.Load(builder);
    }
}