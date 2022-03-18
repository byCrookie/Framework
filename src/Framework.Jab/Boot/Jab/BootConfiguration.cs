using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Workflow;

namespace Framework.Jab.Boot.Jab;

[UsedImplicitly]
public static class BootConfiguration
{
    [UsedImplicitly]
    public static IBootScope<T> Configure<T>(object provider) where T : BootContext
    {
        if (provider is IServiceProvider serviceProvider)
        {
            var workflowBuilder = serviceProvider.GetService<IWorkflowBuilder<T>>();

            if (workflowBuilder is null)
            {
                throw new ArgumentException($"IWorkflowBuilder of type {typeof(T).FullName} has to be registered");
            }
        
            return new BootScope<T>(serviceProvider, workflowBuilder);
        }
        
        throw new ArgumentException($"{nameof(provider)} not of type {nameof(IServiceProvider)}");
    }
}