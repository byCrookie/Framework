using Workflow;

namespace Framework.Autofac.Boot.Start;

public interface IStartBootStep<in TContext> : IWorkflowStep<TContext>
    where TContext : WorkflowBaseContext, IBootContext
{
}