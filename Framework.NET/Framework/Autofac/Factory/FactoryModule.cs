using Autofac;

namespace Framework.Autofac.Factory
{
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
            
            base.Load(builder);
        }
    }
}