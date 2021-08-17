using System;
using System.Threading.Tasks;

namespace Framework.Workflow.Steps.Console
{
    internal class WorkflowWriteLineStep<TContext> : IWorkflowStep<TContext> where TContext : WorkflowBaseContext
    {
        private readonly Func<TContext, Task<string>> _action;

        public WorkflowWriteLineStep(Func<TContext, Task<string>> action)
        {
            _action = action;
        }

        public WorkflowWriteLineStep(Func<TContext, string> action)
        {
            _action = context => Task.FromResult(action(context));
        }

        public Task ExecuteAsync(TContext context)
        {
            System.Console.WriteLine(_action(context));
            return Task.CompletedTask;
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(context.ShouldExecute());
        }
    }
}