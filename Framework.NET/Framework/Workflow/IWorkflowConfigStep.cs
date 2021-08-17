using System;

namespace Framework.Workflow
{
    public interface IWorkflowConfigStep<in TContext, out TConfig> : IWorkflowStep<TContext> where TContext : WorkflowBaseContext
    {
        void SetConfig(Action<TConfig> configure);
    }
}