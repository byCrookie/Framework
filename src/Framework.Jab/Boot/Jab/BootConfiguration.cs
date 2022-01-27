using Microsoft.Extensions.DependencyInjection;
using Workflow;

namespace Framework.Jab.Boot.Jab;

public static class BootConfiguration
{
    public static BootScope<T> Configure<T>() where T : WorkflowBaseContext
    {
        return Configure<T>(new DefaultServiceProvider());
    }

    public static BootScope<T> Configure<T>(IServiceProvider serviceProvider) where T : WorkflowBaseContext
    {
        var workflowBuilder = serviceProvider.GetService<IWorkflowBuilder<T>>();

        return new BootScope<T>(workflowBuilder, serviceProvider);
    }
}