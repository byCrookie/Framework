using Autofac;
using Framework.Hash;

namespace Framework.Autofac.Hash;

internal class HashModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<HashGenerator>().As<IHashGenerator>();
            
        base.Load(builder);
    }
}