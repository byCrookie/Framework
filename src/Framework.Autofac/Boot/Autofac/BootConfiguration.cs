using Autofac;
using JetBrains.Annotations;
using Workflow;

namespace Framework.Autofac.Boot.Autofac;

[UsedImplicitly]
public static class BootConfiguration
{
    [UsedImplicitly]
    public static IBootScope<T> Configure<T>() where T : BootContext
    {
        return Configure<T>(Enumerable.Empty<Module>());
    }

    [UsedImplicitly]
    public static IBootScope<T> Configure<T>(IEnumerable<Module> modules) where T : BootContext
    {
        var builder = new ContainerBuilder();
        var container = builder.Build();
            
        var bootLifeTimeScope = container.BeginLifetimeScope(bootContainer =>
        {
            bootContainer.RegisterModule<FrameworkModule>();

            foreach (var module in modules)
            {
                bootContainer.RegisterModule(module);
            }
        });

        var workflowBuilder = bootLifeTimeScope.Resolve<IWorkflowBuilder<T>>();

        return new BootScope<T>(container, bootLifeTimeScope, workflowBuilder);
    }
}