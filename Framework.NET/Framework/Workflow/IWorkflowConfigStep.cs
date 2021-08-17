namespace Framework.Workflow
{
    public interface IWorkflowConfigStep<in TContext, in TConfig> : IWorkflowStep<TContext> where TContext : WorkflowBaseContext
    {
        void SetConfig(TConfig configuration);
    }
}