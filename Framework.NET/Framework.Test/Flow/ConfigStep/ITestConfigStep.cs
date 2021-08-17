using Framework.Workflow;

namespace Framework.Test.Flow.ConfigStep
{
    public interface ITestConfigStep<in TContext, in TConfig> : IWorkflowConfigStep<TContext, TConfig>
        where TContext : WorkflowBaseContext
    {
    }
}