using Autofac;

namespace Framework.Boot.AssemblyLoad
{
    internal class AssemblyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(AssemblyBootStep<>)).As(typeof(IAssemblyBootStep<>));
            
            base.Load(builder);
        }
    }
}