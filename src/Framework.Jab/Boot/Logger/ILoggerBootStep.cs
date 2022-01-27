using Workflow;

namespace Framework.Jab.Boot.Logger;

public interface ILoggerBootStep<in TContext, in TOptions> : IWorkflowOptionsStep<TContext, TOptions>
    where TContext : WorkflowBaseContext, IBootContext
{
}