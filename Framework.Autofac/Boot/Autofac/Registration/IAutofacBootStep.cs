using Workflow;

namespace Framework.Autofac.Boot.Autofac.Registration;

public interface
    IAutofacBootStep<in TContext, in TOptions> : IWorkflowOptionsStep<TContext, TOptions>
    where TContext : WorkflowBaseContext, IBootContext
{
}