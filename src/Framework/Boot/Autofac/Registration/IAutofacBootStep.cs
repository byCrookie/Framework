using Workflow;

namespace Framework.Boot.Autofac.Registration;

public interface
    IAutofacBootStep<in TContext, in TOptions> : IWorkflowOptionsStep<TContext, TOptions>
    where TContext : WorkflowBaseContext, IBootContext
{
}