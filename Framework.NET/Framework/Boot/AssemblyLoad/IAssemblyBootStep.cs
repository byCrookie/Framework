using Framework.Workflow;

namespace Framework.Boot.AssemblyLoad
{
    public interface IAssemblyBootStep<in TContext>   : IWorkflowStep<TContext> 
        where TContext : WorkflowBaseContext, IBootContext
    {}
}