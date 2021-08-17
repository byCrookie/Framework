using Framework.Workflow;

namespace Framework.Boot.Configuration
{
    public interface
        IFrameworkConfigurationBootStep<in TContext, out TConfig> : IWorkflowConfigStep<TContext, TConfig>
        where TContext : WorkflowBaseContext, IBootContext
    {
    }
}