using Workflow;

namespace Framework.Boot.Logger;

public interface ILoggerBootStep<in TContext, TOptions> : IWorkflowOptionsStep<TContext, TOptions>
    where TContext : WorkflowBaseContext, IBootContext
{
}