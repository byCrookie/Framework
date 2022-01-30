using Workflow;

namespace Framework.Autofac.Tests;

internal interface IWorkflowTestOptionsStep<in TContext, in TOptions> : IWorkflowOptionsStep<TContext, TOptions> where TContext : WorkflowTestContext
{
}