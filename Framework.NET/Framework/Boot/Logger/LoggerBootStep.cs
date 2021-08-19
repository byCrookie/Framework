using System;
using System.Threading.Tasks;
using Autofac;
using Framework.Autofac.Logger;
using Framework.Workflow;
using log4net;

namespace Framework.Boot.Logger
{
    internal class LoggerBootStep<TContext, TOptions> : ILoggerBootStep<TContext, TOptions> where TContext : WorkflowBaseContext, IBootContext
    {
        private LoggerBootStepOptions _options;

        public Task ExecuteAsync(TContext context)
        {
            Log4NetConfigurator.Configure(context.CointainerBuilder, _options.Log4NetConfigurationFile);
            
            context.CointainerBuilder.RegisterType<ApplicationLogger>()
                .WithParameter("logger", LogManager.GetLogger(typeof(IApplication)).Logger)
                .As<IApplicationLogger>();
            
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