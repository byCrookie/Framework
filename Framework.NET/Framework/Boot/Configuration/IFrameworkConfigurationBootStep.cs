using Framework.Workflow;

namespace Framework.Boot.Configuration
{
    public interface
        IFrameworkConfigurationBootStep<in TContext, in TConfig> : IWorkflowConfigStep<TContext, TConfig>
        where TContext : WorkflowBaseContext, IBootContext
    {
    }
}