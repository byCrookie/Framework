using Workflow;

namespace Framework.Boot.Autofac.BuildContainer
{
    public interface IBuildContainerBootStep<in TContext> : IWorkflowStep<TContext> 
        where TContext : WorkflowBaseContext, IBootContext
    {}
}