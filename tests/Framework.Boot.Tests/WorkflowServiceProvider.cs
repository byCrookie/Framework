using Framework.Boot;
using Jab;
using Workflow;

namespace Framework.Tests;

[ServiceProvider]
[Import(typeof(IFrameworkBootModule))]
[Transient(typeof(IWorkflowBuilder<WorkflowTestContext>), typeof(WorkflowBuilder<WorkflowTestContext>))]
[Transient(typeof(IWorkflowTestStep<WorkflowTestContext>), typeof(WorkflowTestStep<WorkflowTestContext>))]
[Transient(typeof(IWorkflowTestOptionsStep<WorkflowTestContext, WorkflowTestStepOptions>), typeof(WorkflowTestOptionsStep<WorkflowTestContext, WorkflowTestStepOptions>))]
public partial class WorkflowServiceProvider
{
}