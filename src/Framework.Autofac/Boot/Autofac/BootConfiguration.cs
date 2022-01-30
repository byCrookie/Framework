using Autofac;
using JetBrains.Annotations;
using Workflow;

namespace Framework.Autofac.Boot.Autofac;

[UsedImplicitly]
public static class BootConfiguration
{
    [UsedImplicitly]
    public static BootScope<T> Configure<T>() where T : WorkflowBaseContext
    {
        return Configure<T>(Enumerable.Empty<Module>());
    }

    [UsedImplicitly]
    public static BootScope<T> Configure<T>(IEnumerable<Module> modules) where T : WorkflowBaseContext
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

        return new BootScope<T>(workflowBuilder);
    }
}