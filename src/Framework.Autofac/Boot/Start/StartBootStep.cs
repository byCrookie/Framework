using Autofac;
using Serilog;

namespace Framework.Autofac.Boot.Start;

internal class StartBootStep<TContext> : IStartBootStep<TContext> where TContext : BootContext
{
    public async Task ExecuteAsync(TContext context)
    {
        var cancellationTokenSource = new CancellationTokenSource();

        try
        {
            await using (var scope = BeginLifetimeScope(context))
            {
                Log.Debug("Autofac LifeTimeScope Started");
                Log.Debug("Resolve Application");
                var app = scope.Resolve<IApplication<TContext>>();
                Log.Debug("Run Application");
                await app.RunAsync(context, cancellationTokenSource.Token).ConfigureAwait(true);
            }
        }
        catch (Exception e)
        {
            Log.Fatal(e, "Error Running Application");
            cancellationTokenSource.Cancel();
            throw;
        }
        finally
        {
            Log.Debug("Cleanup");

            cancellationTokenSource.Dispose();

            Log.Debug("Dispose BootLifetimeScope");
            await context.BootLifetimeScope.DisposeAsync().ConfigureAwait(true);

            Log.Debug("Dispose Container");
            await context.Container.DisposeAsync().ConfigureAwait(true);

            Log.Debug("Dispose Logger");
            Log.CloseAndFlush();
        }
    }

    private static ILifetimeScope BeginLifetimeScope(TContext context)
    {
        Log.Debug("Begin Autofac LifeTimeScope");
        
        return context.Container.BeginLifetimeScope(builder =>
        {
            foreach (var registration in context.RegistrationActions)
            {
                registration(builder);
            }
        });
    }

    public Task<bool> ShouldExecuteAsync(TContext context)
    {
        return Task.FromResult(true);
    }
}