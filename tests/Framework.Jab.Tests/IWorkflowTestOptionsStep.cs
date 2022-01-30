using Workflow;

namespace Framework.Jab.Tests;

internal interface IWorkflowTestOptionsStep<in TContext, in TOptions> : IWorkflowOptionsStep<TContext, TOptions> where TContext : WorkflowTestContext
{
}