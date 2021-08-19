using Framework.Workflow;

namespace Framework.Boot.Configuration
{
    public interface
        IFrameworkConfigurationBootStep<in TContext, in TOptions> : IWorkflowOptionsStep<TContext, TOptions>
        where TContext : WorkflowBaseContext, IBootContext
    {
    }
}