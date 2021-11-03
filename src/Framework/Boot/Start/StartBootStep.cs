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
                    try
                    {
                        var app = scope.Resolve<IApplication>();
                        await app.RunAsync(cancellationTokenSource.Token).ConfigureAwait(true);
                    }
                    catch (Exception e)
                    {
                        if (scope.TryResolve<IApplicationLogger>(out var logger))
                        {
                            logger.Error(e.Demystify());
                        }
                        
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                cancellationTokenSource.Cancel();
                Console.WriteLine(e.Demystify());
                throw;
            }
            finally
            {
                cancellationTokenSource.Dispose();
                if (context.BootLifetimeScope is not null)
                {
                    await context.BootLifetimeScope.DisposeAsync().ConfigureAwait(true);
                }

                if (context.LifetimeScope is not null)
                {
                    await context.LifetimeScope.DisposeAsync().ConfigureAwait(true);
                }

                if (context.Container is not null)
                {
                    await context.Container.DisposeAsync().ConfigureAwait(true);
                }
            }
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }
    }
}