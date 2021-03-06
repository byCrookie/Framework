using Workflow;

namespace Framework.Autofac.Tests;

internal interface IWorkflowTestStep<in TContext> : IWorkflowStep<TContext> where TContext : WorkflowTestContext
{
}