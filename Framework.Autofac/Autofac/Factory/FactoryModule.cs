using Autofac;
using Framework.Jab.Jab.Factory;

namespace Framework.Autofac.Autofac.Factory;

internal class FactoryModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Factory>().As<IFactory>();
        builder.RegisterGeneric(typeof(Factory<>)).As(typeof(IFactory<>));
        builder.RegisterGeneric(typeof(Factory<,>)).As(typeof(IFactory<,>));
        builder.RegisterGeneric(typeof(Factory<,,>)).As(typeof(IFactory<,,>));
        builder.RegisterGeneric(typeof(Factory<,,,>)).As(typeof(IFactory<,,,>));
        builder.RegisterGeneric(typeof(Factory<,,,,>)).As(typeof(IFactory<,,,,>));
        builder.RegisterGeneric(typeof(Factory<,,,,,>)).As(typeof(IFactory<,,,,,>));
            
        builder.RegisterType<KeyedFactory>().As<IKeyedFactory>();
        builder.RegisterGeneric(typeof(KeyedFactory<>)).As(typeof(IKeyedFactory<>));
            
        base.Load(builder);
    }
}