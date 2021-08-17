using System;
using System.Threading.Tasks;
using Autofac;
using Framework.Autofac.Logger;
using Framework.Workflow;
using log4net;

namespace Framework.Boot.Logger
{
    internal class LoggerBootStep<TContext, TConfig> : ILoggerBootStep<TContext, TConfig> where TContext : WorkflowBaseContext, IBootContext
    {
        private LoggerBootStepConfiguration _configuration;

        public Task ExecuteAsync(TContext context)
        {
            Log4NetConfigurator.Configure(context.CointainerBuilder, _configuration.Log4NetConfigurationFile);
            
            context.CointainerBuilder.RegisterType<ApplicationLogger>()
                .WithParameter("logger", LogManager.GetLogger(typeof(IApplication)).Logger)
                .As<IApplicationLogger>();
            
            return Task.CompletedTask;
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }

        public void SetConfig(Action<TConfig> configure)
        {
            var configuration = Activator.CreateInstance<TConfig>();
            configure?.Invoke(configuration);
            _configuration = configuration as LoggerBootStepConfiguration;
        }
    }
}