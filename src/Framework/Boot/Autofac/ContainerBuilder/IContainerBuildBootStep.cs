using Framework.Workflow;

namespace Framework.Boot.Autofac.ContainerBuilder
{
    public interface IContainerBuildBootStep<TContext> : IWorkflowStep<TContext> 
        where TContext : WorkflowBaseContext, IBootContext
    {}
}