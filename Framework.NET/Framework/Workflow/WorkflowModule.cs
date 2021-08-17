using Autofac;
using Framework.Workflow.Steps.If;
using Framework.Workflow.Steps.IfElse.IfElseReturn;
using Framework.Workflow.Steps.Then;

namespace Framework.Workflow
{
    internal class WorkflowModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(WorkflowBuilder<>)).As(typeof(IWorkflowBuilder<>));
            builder.RegisterGeneric(typeof(WorkflowReturnStep<,>)).As(typeof(IWorkflowReturnStep<>));
            builder.RegisterGeneric(typeof(WorkflowConditionReturnStep<,>)).As(typeof(IWorkflowConditionReturnStep<>));
            builder.RegisterGeneric(typeof(WorkflowIfElseReturnStep<,>)).As(typeof(IWorkflowIfElseReturnStep<>));

            base.Load(builder);
        }
    }
}