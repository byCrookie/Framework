using Serilog;
using Workflow;

namespace Framework.Jab.Boot.Start;

internal class StartBootStep<TContext> : IStartBootStep<TContext> where TContext : WorkflowBaseContext, IBootContext
{
    public async Task ExecuteAsync(TContext context)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Debug()
            .CreateLogger();

        var cancellationTokenSource = new CancellationTokenSource();

        try
        {
            await using (var scope = BeginScope(context))
            {
                Log.Debug("Autofac LifeTimeScope Started");
                Log.Debug("Resolve Application");
                var app = scope.GetService<IApplication>();
                Log.Information("Run Application");
                await app.RunAsync(cancellationTokenSource.Token).ConfigureAwait(true);
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

            Log.Debug("Dispose Service Provider");
            await context.ServiceProvider.DisposeAsync().ConfigureAwait(true);

            Log.Debug("Dispose Logger");
            Log.CloseAndFlush();
        }
    }

    private static DefaultServiceProvider.Scope BeginScope(TContext context)
    {
        Log.Debug("Begin Jab Scope");
        return context.ServiceProvider.CreateScope();
    }

    public Task<bool> ShouldExecuteAsync(TContext context)
    {
        return Task.FromResult(true);
    }
}