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
            Log.Debug("Autofac LifeTimeScope Started");
            Log.Debug("Resolve Application");
            if (context.ServiceProvider.GetService(typeof(IApplication)) is not IApplication app)
            {
                throw new ArgumentException($"Can not resolve {nameof(IApplication)}");
            }
            Log.Information("Run Application");
            await app.RunAsync(cancellationTokenSource.Token).ConfigureAwait(true);
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

            Log.Debug("Dispose Logger");
            Log.CloseAndFlush();
        }
    }

    public Task<bool> ShouldExecuteAsync(TContext context)
    {
        return Task.FromResult(true);
    }
}