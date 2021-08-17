using Autofac;

namespace Framework.Unique
{
    internal class UniqueModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UniqueGenerator>().As<IUniqueGenerator>();
            
            base.Load(builder);
        }
    }
}