using Autofac;
using Framework.Autofac.Boot.Autofac.Registration;

namespace Framework.Autofac.Boot.Autofac;

internal class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(AutofacBootStep<,>)).As(typeof(IAutofacBootStep<,>));

        base.Load(builder);
    }
}