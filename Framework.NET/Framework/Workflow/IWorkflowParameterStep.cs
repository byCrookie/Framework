namespace Framework.Workflow
{
    public interface IWorkflowParameterStep<in TContext, in TParameter> : IWorkflowStep<TContext> where TContext : WorkflowBaseContext
    {
        void SetParameter(TParameter parameter);
    }
}