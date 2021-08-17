using System.Threading.Tasks;
using Framework.Workflow;

namespace Framework.Boot.Autofac.ContainerBuilder
{
    internal class ContainerBuildBootStep<TContext> : IContainerBuildBootStep<TContext>
        where TContext : WorkflowBaseContext, IBootContext
    {
        public Task ExecuteAsync(TContext context)
        {
            context.CointainerBuilder = new global::Autofac.ContainerBuilder();
            return Task.CompletedTask;
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }
    }
}