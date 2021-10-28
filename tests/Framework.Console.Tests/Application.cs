using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Framework.Boot;
using Framework.Console.Tests.Selection;
using Workflow;

namespace Framework.Console.Tests
{
    public class Application : IApplication
    {
        private readonly IWorkflowBuilder<ConsoleTestContext> _workflowBuilder;

        public Application(IWorkflowBuilder<ConsoleTestContext> workflowBuilder)
        {
            _workflowBuilder = workflowBuilder;
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            var result = await MultiInputWorkflow().RunAsync(new ConsoleTestContext()).ConfigureAwait(false);
            var test = result.MultiLineInput;
        }

        private IWorkflow<ConsoleTestContext> MultiInputWorkflow()
        {
            return _workflowBuilder
                .WriteLine(_ => "Input MultiLine Input")
                .ReadMultiLine(context => context.MultiLineInput, options =>
                {
                    options.EndOfInput = ")";
                    options.RemoveEndOfInput = false;
                    options.ShouldTrimLines = true;
                })
                .Write(context => $"{context.MultiLineInput}")
                .Build();
        } 
        
        private IWorkflow<ConsoleTestContext> BigWorkflow()
        {
            return _workflowBuilder
                .While(c => c.Selection != 1, whileFlow => whileFlow
                    .ThenAsync<ISelectionStep<ConsoleTestContext, SelectionStepOptions>,
                        SelectionStepOptions>(
                        config => { config.Selections = new List<string> {"Valid", "Invalid"}; }
                    )
                    .IfElseFlow(c => c.Selection == 2, ifflow => ifflow
                        .WriteLine(c => $"selection was invalid {c.Selection}"), elseFlow => elseFlow
                        .WriteLine(c => $"selection was invalid {c.Selection}"))
                )
                .WriteLine(c => $"selection was valid {c.Selection}")
                .Throw<Exception>(c => c.Selection = 100)
                .Catch(c => System.Console.WriteLine(c.Selection))
                .ReadKey(c => c.Key)
                .WriteLine(c => $"{c.Key.Key}")
                .Build();
        }

        private IWorkflow<ConsoleTestContext> SelectionWorkflow()
        {
            return _workflowBuilder
                .ThenAsync<ISelectionStep<ConsoleTestContext, SelectionStepOptions>, SelectionStepOptions>(
                    config => { config.Selections = new List<string> {"ABC", "BCD"}; }
                )
                .WriteLine(c => $"{c.Selection}")
                .WriteLine(_ => "Input single input")
                .ReadLine(context => context.SingleInput)
                .WriteLine(context => context.SingleInput)
                .Build();
        }
    }
}