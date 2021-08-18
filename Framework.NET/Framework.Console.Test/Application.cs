using System.Threading;
using System.Threading.Tasks;
using Framework.Boot;
using Framework.Workflow;

namespace Framework.Console.Test
{
    public class Application : IApplication
    {
        private readonly IWorkflowBuilder<ConsoleTestContext> _workflowBuilder;

        public Application(IWorkflowBuilder<ConsoleTestContext> workflowBuilder)
        {
            _workflowBuilder = workflowBuilder;
        }

        public Task RunAsync(CancellationToken cancellationToken)
        {
            var workflow = _workflowBuilder
                .WriteLine(_ => "Input MultiLine Input")
                .ReadMultiLine(context => context.MultiLineInput, ":!q")
                .Write(context => $"{context.MultiLineInput}")
                .Build();

            return workflow.RunAsync(new ConsoleTestContext());
        }
    }
}