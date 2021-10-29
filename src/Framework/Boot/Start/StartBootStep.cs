using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Framework.Boot.Logger;
using Workflow;

namespace Framework.Boot.Start
{
    internal class StartBootStep<TContext> : IStartBootStep<TContext> where TContext : WorkflowBaseContext, IBootContext
    {
        public async Task ExecuteAsync(TContext context)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            try
            {
                await using (var scope = context.Container.BeginLifetimeScope(builder =>
                {
                    foreach (var registration in context.RegistrationActions)
                    {
                        registration(builder);
                    }
                }))
                {
                    var app = scope.Resolve<IApplication>();
                    await app.RunAsync(cancellationTokenSource.Token).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                cancellationTokenSource.Cancel();
                var scope = context.Container;
                var logger = scope.Resolve<IApplicationLogger>();
                logger.Error(e.Demystify());
                throw;
            }
            finally
            {
                cancellationTokenSource.Dispose();
                await context.BootLifetimeScope.DisposeAsync().ConfigureAwait(false);
                await context.LifetimeScope.DisposeAsync().ConfigureAwait(false);
                await context.Container.DisposeAsync().ConfigureAwait(false);
            }
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }
    }
}