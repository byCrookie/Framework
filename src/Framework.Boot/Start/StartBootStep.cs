using Serilog;
using Workflow;

namespace Framework.Boot.Start;

public class StartBootStep<TContext> : IStartBootStep<TContext> where TContext : WorkflowBaseContext, IInternalBootContext
{
    public async Task ExecuteAsync(TContext context)
    {
        var cancellationTokenSource = new CancellationTokenSource();

        try
        {
            Log.Debug("Resolve Application");
            if (context.ServiceProvider.GetService(typeof(IApplication<TContext>)) is not IApplication<TContext> app)
            {
                throw new ArgumentException($"Can not resolve {nameof(IApplication<TContext>)}");
            }
            Log.Debug("Run Application");
            await app.RunAsync(context, cancellationTokenSource.Token).ConfigureAwait(true);
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