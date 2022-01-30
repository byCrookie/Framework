using Autofac;

namespace Framework.Autofac.Boot.Start;

internal class StartModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(StartBootStep<>)).As(typeof(IStartBootStep<>));
            
        base.Load(builder);
    }
}