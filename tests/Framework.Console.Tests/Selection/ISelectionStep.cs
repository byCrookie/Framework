using Framework.Workflow;

namespace Framework.Console.Tests.Selection
{
    internal interface ISelectionStep<in TContext, in TOptions> : 
        IWorkflowOptionsStep<TContext, TOptions>
        where TContext : WorkflowBaseContext
    {
    }
}