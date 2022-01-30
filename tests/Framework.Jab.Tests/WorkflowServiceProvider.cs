using Jab;
using Workflow;
using Workflow.Jab;

namespace Framework.Jab.Tests;

[ServiceProvider]
[Import(typeof(IFrameworkModule))]
[Transient(typeof(IWorkflowBuilder<WorkflowTestContext>), typeof(WorkflowBuilder<WorkflowTestContext>))]
[Transient(typeof(IWorkflowTestStep<WorkflowTestContext>), typeof(WorkflowTestStep<WorkflowTestContext>))]
[Transient(typeof(IWorkflowTestOptionsStep<WorkflowTestContext, WorkflowTestStepOptions>), typeof(WorkflowTestOptionsStep<WorkflowTestContext, WorkflowTestStepOptions>))]
internal partial class WorkflowServiceProvider
{
}