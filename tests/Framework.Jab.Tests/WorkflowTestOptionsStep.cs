using System.Threading.Tasks;

namespace Framework.Jab.Tests;

public class WorkflowTestOptionsStep<TContext, TOptions> : IWorkflowTestOptionsStep<TContext, TOptions> where TContext : WorkflowTestContext
{
    private WorkflowTestStepOptions? _options;

    public Task ExecuteAsync(TContext context)
    {
        var workflowTestContext = context as WorkflowTestContext;
        workflowTestContext.Valid = _options?.IsValid ?? false;
        return Task.CompletedTask;
    }

    public Task<bool> ShouldExecuteAsync(TContext context)
    {
        return context.ShouldExecuteAsync();
    }

    public void SetOptions(TOptions options)
    {
        _options = options as WorkflowTestStepOptions;
    }
}