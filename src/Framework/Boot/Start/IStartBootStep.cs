using Framework.Workflow;

namespace Framework.Boot.Start
{
    public interface IStartBootStep<TContext>   : IWorkflowStep<TContext> 
        where TContext : WorkflowBaseContext, IBootContext
    {}
}