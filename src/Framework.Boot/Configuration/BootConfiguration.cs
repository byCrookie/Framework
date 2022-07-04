using JetBrains.Annotations;
using Workflow;

namespace Framework.Boot.Configuration;

[UsedImplicitly]
public static class BootConfiguration
{
    [UsedImplicitly]
    public static IBootScope<T> Configure<T>(object provider) where T : BootContext
    {
        if (provider is IServiceProvider serviceProvider)
        {
            var workflowBuilder = serviceProvider.GetService(typeof(IWorkflowBuilder<T>));

            if (workflowBuilder is null)
            {
                throw new ArgumentException($"IWorkflowBuilder of type {typeof(T).FullName} has to be registered");
            }
        
            return new BootScope<T>(serviceProvider, (IWorkflowBuilder<T>)workflowBuilder);
        }
        
        throw new ArgumentException($"{nameof(provider)} not of type {nameof(IServiceProvider)}");
    }
}