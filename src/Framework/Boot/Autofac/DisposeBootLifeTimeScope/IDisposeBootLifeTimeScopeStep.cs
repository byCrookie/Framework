using Workflow;

namespace Framework.Boot.Autofac.DisposeBootLifeTimeScope
{
    public interface IDisposeBootLifeTimeScopeStep<in TContext> : IWorkflowStep<TContext> 
        where TContext : WorkflowBaseContext, IBootContext
    {}
}