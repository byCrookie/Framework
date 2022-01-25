using Autofac;
using Framework.Boot.Autofac.Registration;

namespace Framework.Boot.Autofac;

internal class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(AutofacBootStep<,>)).As(typeof(IAutofacBootStep<,>));

        base.Load(builder);
    }
}