using Workflow;

namespace Framework.Boot.Start;

public interface IStartBootStep<in TContext>   : IWorkflowStep<TContext> 
    where TContext : WorkflowBaseContext, IBootContext
{}