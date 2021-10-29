using System.Threading.Tasks;
using Framework.Extensions.List;
using Workflow;

namespace Framework.Boot.Autofac.BeginLifeTimeScope
{
    internal class BeginLifeTimeScopeBootStep<TContext> : IBeginLifeTimeScopeBootStep<TContext>
        where TContext : WorkflowBaseContext, IBootContext
    {
        public Task ExecuteAsync(TContext context)
        {
            context.LifetimeScope = context.Container.BeginLifetimeScope(builder =>
            {
                context.RegistrationActions.ForEach(action => action(builder));
            });
            
            return Task.CompletedTask;
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }
    }
}