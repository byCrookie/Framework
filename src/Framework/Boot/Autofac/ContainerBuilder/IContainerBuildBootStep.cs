using Workflow;

namespace Framework.Boot.Autofac.ContainerBuilder
{
    public interface IContainerBuildBootStep<in TContext> : IWorkflowStep<TContext> 
        where TContext : WorkflowBaseContext, IBootContext
    {}
}