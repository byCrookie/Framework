using Framework.Workflow;

namespace Framework.Console.Test.Selection
{
    internal interface ISelectionStep<in TContext, in TConfig> : 
        IWorkflowConfigStep<TContext, TConfig>
        where TContext : WorkflowBaseContext
    {
    }
}