using Workflow;

namespace Framework.Tests;

internal interface IWorkflowTestOptionsStep<in TContext, in TOptions> : IWorkflowOptionsStep<TContext, TOptions> where TContext : WorkflowTestContext
{
}