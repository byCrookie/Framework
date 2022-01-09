using System.Threading.Tasks;
using Serilog;
using Workflow;

namespace Framework.Boot.Logger
{
    internal class LoggerBootStep<TContext, TOptions> : ILoggerBootStep<TContext, TOptions> where TContext : WorkflowBaseContext, IBootContext
    {
        private LoggerBootStepOptions _options;

        public Task ExecuteAsync(TContext context)
        {
            Log.Logger = _options.Configuration.CreateLogger();
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
}