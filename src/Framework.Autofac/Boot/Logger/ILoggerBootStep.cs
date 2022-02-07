using Workflow;

namespace Framework.Autofac.Boot.Logger;

public interface ILoggerBootStep<in TContext, in TOptions> : IWorkflowOptionsStep<TContext, TOptions>
    where TContext : BootContext
{
}