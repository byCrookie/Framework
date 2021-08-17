using Framework.Workflow;

namespace Framework.Boot.Autofac.BuildContainer
{
    public interface IBuildContainerBootStep<TContext> : IWorkflowStep<TContext> 
        where TContext : WorkflowBaseContext, IBootContext
    {}
}