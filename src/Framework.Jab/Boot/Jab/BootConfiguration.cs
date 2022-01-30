using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Workflow;

namespace Framework.Jab.Boot.Jab;

[UsedImplicitly]
public static class BootConfiguration
{
    [UsedImplicitly]
    public static BootScope<T> Configure<T>(IServiceProvider serviceProvider) where T : WorkflowBaseContext
    {
        var workflowBuilder = serviceProvider.GetService<IWorkflowBuilder<T>>();

        if (workflowBuilder is null)
        {
            throw new ArgumentException($"IWorkflowBuilder of type {typeof(T).FullName} has to be registered");
        }
        
        return new BootScope<T>(workflowBuilder);
    }
}