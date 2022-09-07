namespace Framework.Tests;

public class WorkflowTestOptionsStep<TContext, TOptions> : IWorkflowTestOptionsStep<TContext, TOptions> where TContext : WorkflowTestContext
{
    private Lazy<WorkflowTestStepOptions>? _options;

    public Task ExecuteAsync(TContext context)
    {
        var workflowTestContext = context as WorkflowTestContext;
        workflowTestContext.Valid = _options?.Value.IsValid ?? false;
        return Task.CompletedTask;
    }

    public Task<bool> ShouldExecuteAsync(TContext context)
    {
        return context.ShouldExecuteAsync();
    }

    public void SetOptions(Lazy<TOptions> options)
    {
        _options = options as Lazy<WorkflowTestStepOptions>;
    }
}