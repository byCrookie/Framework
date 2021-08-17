using Framework.Workflow;

namespace Framework.Boot.Logger
{
    public interface ILoggerBootStep<in TContext, out TConfig> : IWorkflowConfigStep<TContext, TConfig>
        where TContext : WorkflowBaseContext, IBootContext
    {
    }
}