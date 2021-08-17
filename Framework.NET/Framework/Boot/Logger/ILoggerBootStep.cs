using Framework.Workflow;

namespace Framework.Boot.Logger
{
    public interface ILoggerBootStep<in TContext, in TConfig> : IWorkflowConfigStep<TContext, TConfig>
        where TContext : WorkflowBaseContext, IBootContext
    {
    }
}