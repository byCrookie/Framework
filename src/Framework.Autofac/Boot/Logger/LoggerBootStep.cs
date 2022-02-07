using Serilog;
using Serilog.Events;

namespace Framework.Autofac.Boot.Logger;

internal class LoggerBootStep<TContext, TOptions> : ILoggerBootStep<TContext, TOptions> where TContext : BootContext
{
    private LoggerBootStepOptions? _options;

    public Task ExecuteAsync(TContext context)
    {
        var config = _options?.Configuration;
        
        config?.WriteTo.Debug(LogEventLevel.Debug);

        Log.Logger = config?.CreateLogger() ?? Serilog.Core.Logger.None;
        return Task.CompletedTask;
    }

    public Task<bool> ShouldExecuteAsync(TContext context)
    {
        return Task.FromResult(true);
    }

    public void SetOptions(TOptions options)
    {
        _options = options as LoggerBootStepOptions;
    }
}