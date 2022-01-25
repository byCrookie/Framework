using Autofac;

namespace Framework.Time;

internal class TimeModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DateTimeProvider>().As<IDateTimeProvider>();
            
        base.Load(builder);
    }
}