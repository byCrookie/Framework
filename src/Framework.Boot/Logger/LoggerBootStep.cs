using Serilog;
using Workflow;

namespace Framework.Boot.Logger;

public class LoggerBootStep<TContext, TOptions> : ILoggerBootStep<TContext, TOptions> where TContext : WorkflowBaseContext, IBootContext
{
    private Lazy<LoggerBootStepOptions>? _options;

    public Task ExecuteAsync(TContext context)
    {
        var config = _options?.Value.Configuration;
        Log.Logger = config?.CreateLogger() ?? Serilog.Core.Logger.None;
        return Task.CompletedTask;
    }

    public Task<bool> ShouldExecuteAsync(TContext context)
    {
        return Task.FromResult(true);
    }

    public void SetOptions(Lazy<TOptions> options)
    {
        _options = options as Lazy<LoggerBootStepOptions>;
    }
}