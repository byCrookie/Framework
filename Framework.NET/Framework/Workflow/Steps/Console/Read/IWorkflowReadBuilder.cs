using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Framework.Workflow.Steps.Console.Read
{
    public interface IWorkflowReadBuilder<TContext> where TContext : WorkflowBaseContext
    {
        IWorkflowBuilder<TContext> ReadLine(Expression<Func<TContext, string>> propertyPicker);
        IWorkflowBuilder<TContext> Read(Expression<Func<TContext, int>> propertyPicker);
        IWorkflowBuilder<TContext> ReadKey(Expression<Func<TContext, ConsoleKeyInfo>> propertyPicker);
        IWorkflowBuilder<TContext> ReadMultiLine(Expression<Func<TContext, string>> propertyPicker, string endOfInput);
    }
}