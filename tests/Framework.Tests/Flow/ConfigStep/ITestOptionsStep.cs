using Framework.Workflow;

namespace Framework.Tests.Flow.ConfigStep
{
    public interface ITestOptionsStep<in TContext, in TOptions> : IWorkflowOptionsStep<TContext, TOptions>
        where TContext : WorkflowBaseContext
    {
    }
}