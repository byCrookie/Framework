using Workflow;

namespace Framework.Boot.Autofac.BeginLifeTimeScope
{
    public interface IBeginLifeTimeScopeBootStep<in TContext> : IWorkflowStep<TContext> 
        where TContext : WorkflowBaseContext, IBootContext
    {}
}