using Workflow;

namespace Framework.Jab.Tests;

internal interface IWorkflowTestStep<in TContext> : IWorkflowStep<TContext> where TContext : WorkflowTestContext
{
}