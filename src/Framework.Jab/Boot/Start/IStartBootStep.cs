using Workflow;

namespace Framework.Jab.Boot.Start;

public interface IStartBootStep<in TContext> : IWorkflowStep<TContext>
    where TContext : WorkflowBaseContext, IBootContext
{
}