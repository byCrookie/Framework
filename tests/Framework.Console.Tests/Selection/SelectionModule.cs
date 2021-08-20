using Autofac;

namespace Framework.Console.Tests.Selection
{
    internal class SelectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(SelectionStep<,>)).As(typeof(ISelectionStep<,>));

            base.Load(builder);
        }
    }
}