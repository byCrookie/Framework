using System.Threading.Tasks;
using Autofac;
using Framework.Autofac.Logger;
using log4net;
using Workflow;

namespace Framework.Boot.Logger
{
    internal class LoggerBootStep<TContext, TOptions> : ILoggerBootStep<TContext, TOptions> where TContext : WorkflowBaseContext, IBootContext
    {
        private LoggerBootStepOptions _options;

        public Task ExecuteAsync(TContext context)
        {
            var action = Log4NetConfigurator.Configure(_options.Log4NetConfigurationFile);
            
            context.RegistrationActions.Add(action);

            context.RegistrationActions.Add(builder => builder.RegisterType<ApplicationLogger>()
                .WithParameter("logger", LogManager.GetLogger(typeof(IApplication)).Logger)
                .As<IApplicationLogger>());

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