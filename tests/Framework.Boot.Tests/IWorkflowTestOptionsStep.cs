using Workflow;

namespace Framework.Tests;

internal interface IWorkflowTestOptionsStep<in TContext, TOptions> : IWorkflowOptionsStep<TContext, TOptions> where TContext : WorkflowTestContext
{
}