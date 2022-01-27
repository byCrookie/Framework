using Workflow;

namespace Framework.Jab.Boot.Jab.Registration;

public interface
    IJabBootStep<in TContext, in TOptions> : IWorkflowOptionsStep<TContext, TOptions>
    where TContext : WorkflowBaseContext, IBootContext
{
}