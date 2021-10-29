using Workflow;

namespace Framework.Boot.TypeLoad
{
    public interface ITypeBootStep<in TContext>   : IWorkflowStep<TContext> 
        where TContext : WorkflowBaseContext, IBootContext
    {}
}