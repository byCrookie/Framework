using System.Threading.Tasks;
using Workflow;

namespace Framework.Boot.Autofac.DisposeBootLifeTimeScope
{
    internal class DisposeBootLifeTimeScopeStepStep<TContext> : IDisposeBootLifeTimeScopeStep<TContext>
        where TContext : WorkflowBaseContext, IBootContext
    {
        public async Task ExecuteAsync(TContext context)
        {
            await context.BootLifetimeScope.DisposeAsync();
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }
    }
}