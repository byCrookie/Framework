using Autofac;

namespace Framework.Boot.TypeLoad
{
    internal class TypeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TypeEvaluator>().As<ITypeEvaluator>();
            builder.RegisterGeneric(typeof(TypeBootStep<>)).As(typeof(ITypeBootStep<>));
            
            base.Load(builder);
        }
    }
}