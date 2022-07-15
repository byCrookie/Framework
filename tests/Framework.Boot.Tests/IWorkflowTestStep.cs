using Workflow;

namespace Framework.Tests;

internal interface IWorkflowTestStep<in TContext> : IWorkflowStep<TContext> where TContext : WorkflowTestContext
{
}