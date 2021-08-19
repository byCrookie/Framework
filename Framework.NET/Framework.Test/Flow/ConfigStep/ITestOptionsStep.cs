using Framework.Workflow;

namespace Framework.Test.Flow.ConfigStep
{
    public interface ITestOptionsStep<in TContext, in TOptions> : IWorkflowOptionsStep<TContext, TOptions>
        where TContext : WorkflowBaseContext
    {
    }
}