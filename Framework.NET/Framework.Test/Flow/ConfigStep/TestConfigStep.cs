using System;
using System.Threading.Tasks;
using Autofac;
using Framework.Autofac.Logger;
using Framework.Boot;
using Framework.Boot.Logger;
using Framework.Workflow;
using log4net;

namespace Framework.Test.Flow.ConfigStep
{
    internal class TestConfigStep<TContext, TConfig> : ITestConfigStep<TContext, TConfig> where TContext : WorkflowBaseContext
    {
        private TestStepConfiguration _stepConfiguration;

        public Task ExecuteAsync(TContext context)
        {
            if (context is TestContext testContext)
            {
                testContext.Config = _stepConfiguration;
            }

            return Task.CompletedTask;
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }

        public void SetConfig(TConfig configuration)
        {
            _stepConfiguration = configuration as TestStepConfiguration;
        }
    }
}