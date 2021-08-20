namespace Framework.Workflow.Steps.Then
{
    internal interface IWorkflowReturnStep<in TContext> : IWorkflowStep<TContext> where TContext : WorkflowBaseContext
    {}
}