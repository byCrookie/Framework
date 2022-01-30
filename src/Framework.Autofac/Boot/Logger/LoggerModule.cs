using Autofac;

namespace Framework.Autofac.Boot.Logger;

internal class LoggerModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(LoggerBootStep<,>)).As(typeof(ILoggerBootStep<,>));
            
        base.Load(builder);
    }
}