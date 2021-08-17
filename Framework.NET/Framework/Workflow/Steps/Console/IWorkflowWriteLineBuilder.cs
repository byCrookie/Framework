using System;
using System.Threading.Tasks;

namespace Framework.Workflow.Steps.Console
{
    public interface IWorkflowWriteLineBuilder<TContext> where TContext : WorkflowBaseContext
    {
        IWorkflowBuilder<TContext> WriteLine(Func<TContext, string> action);
        IWorkflowBuilder<TContext> WriteLineAsync(Func<TContext, Task<string>> action);
    }
}