using Framework.Workflow.Steps.Catch;
using Framework.Workflow.Steps.Console;
using Framework.Workflow.Steps.Console.Read;
using Framework.Workflow.Steps.Console.Write;
using Framework.Workflow.Steps.If;
using Framework.Workflow.Steps.IfElse;
using Framework.Workflow.Steps.Stop;
using Framework.Workflow.Steps.Then;
using Framework.Workflow.Steps.Throw;
using Framework.Workflow.Steps.While;

namespace Framework.Workflow
{
    public interface IWorkflowBuilder<TContext> :
        IWorkflowCatchBuilder<TContext>,
        IWorkflowThrowBuilder<TContext>,
        IWorkflowStopBuilder<TContext>,
        IWorkflowWhileBuilder<TContext>,
        IWorkflowThenBuilder<TContext>,
        IWorkflowIfElseBuilder<TContext>,
        IWorkflowIfBuilder<TContext>,
        IWorkflowWriteBuilder<TContext>,
        IWorkflowReadBuilder<TContext>
        where TContext : WorkflowBaseContext
    {
        IWorkflow<TContext> Build();
    }
}