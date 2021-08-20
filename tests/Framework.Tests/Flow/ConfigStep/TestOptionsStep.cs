using System.Threading.Tasks;
using Framework.Workflow;

namespace Framework.Tests.Flow.ConfigStep
{
    internal class TestOptionsStep<TContext, TOptions> : ITestOptionsStep<TContext, TOptions> where TContext : WorkflowBaseContext
    {
        private TestStepOptions _stepOptions;

        public Task ExecuteAsync(TContext context)
        {
            if (context is TestContext testContext)
            {
                testContext.Config = _stepOptions;
            }

            return Task.CompletedTask;
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }

        public void SetOptions(TOptions options)
        {
            _stepOptions = options as TestStepOptions;
        }
    }
}