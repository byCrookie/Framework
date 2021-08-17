using Autofac;

namespace Framework.Hash
{
    internal class HashModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HashGenerator>().As<IHashGenerator>();
            
            base.Load(builder);
        }
    }
}