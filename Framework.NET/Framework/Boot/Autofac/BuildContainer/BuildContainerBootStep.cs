using System.Threading.Tasks;
using Framework.Workflow;

namespace Framework.Boot.Autofac.BuildContainer
{
    internal class BuildContainerBootStep<TContext> : IBuildContainerBootStep<TContext>
        where TContext : WorkflowBaseContext, IBootContext
    {
        public Task ExecuteAsync(TContext context)
        {
            context.Container = context.CointainerBuilder.Build();
            return Task.CompletedTask;
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }
    }
}