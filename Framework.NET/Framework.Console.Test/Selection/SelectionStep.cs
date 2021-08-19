using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Framework.Workflow;

namespace Framework.Console.Test.Selection
{
    internal class SelectionStep<TContext, TConfig> :
        ISelectionStep<TContext, TConfig>
        where TContext : WorkflowBaseContext, ISelectionContext
    {
        private readonly IWorkflowBuilder<SelectionContext> _workflowBuilder;
        private SelectionStepConfiguration _configuration;

        public SelectionStep(IWorkflowBuilder<SelectionContext> workflowBuilder)
        {
            _workflowBuilder = workflowBuilder;
        }

        public async Task ExecuteAsync(TContext context)
        {
            var selectionContext = new SelectionContext();

            var workflow = _workflowBuilder
                .While(c => c.Selection == 0 || c.Selection > _configuration.Selections.Count, whileFlow => whileFlow
                    .WriteLine(c => $"{c.Selection == 0} {c.Selection > _configuration.Selections.Count}")
                    .WriteLine(_ => @"Select an option")
                    .WriteLine(_ => CreateSelectionMenu(_configuration.Selections))
                    .ReadLine(c => c.Input)
                    .IfFlow(c => string.IsNullOrEmpty(c.Input.Trim()), ifFlow => ifFlow
                        .WriteLine(_ => @"Press enter to exit or space to continue")
                        .IfFlow(_ => System.Console.ReadKey().Key == ConsoleKey.Enter, ifFlowLeave => ifFlowLeave
                            .StopAsync(context)
                        )
                    )
                    .Then(c => c.Selection, c => Convert.ToInt16(c.Input.Trim()))
                    .If(c => c.Selection > _configuration.Selections.Count || c.Selection < 1, _ => System.Console.WriteLine($@"Option is not valid"))
                )
                .Build();

            var workflowContext = await workflow.RunAsync(selectionContext).ConfigureAwait(false);
            context.Selection = workflowContext.Selection;
        }

        private static string CreateSelectionMenu(IReadOnlyList<string> selections)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            for (var index = 0; index < selections.Count; index++)
            {
                stringBuilder.AppendLine($@" {index + 1} - {selections[index]}");
            }

            stringBuilder.AppendLine();
            return stringBuilder.ToString();
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(context.ShouldExecute());
        }

        public void SetConfig(TConfig configuration)
        {
            _configuration = configuration as SelectionStepConfiguration;
        }
    }
}