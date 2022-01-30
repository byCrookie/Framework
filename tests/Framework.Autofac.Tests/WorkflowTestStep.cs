using System.Threading.Tasks;

namespace Framework.Autofac.Tests;

public class WorkflowTestStep<TContext> : IWorkflowTestStep<TContext> where TContext : WorkflowTestContext
{
    public Task ExecuteAsync(TContext context)
    {
        var workflowTestContext = context as WorkflowTestContext;
        workflowTestContext.Valid = true;
        return Task.CompletedTask;
    }

    public Task<bool> ShouldExecuteAsync(TContext context)
    {
        return context.ShouldExecuteAsync();
    }
}