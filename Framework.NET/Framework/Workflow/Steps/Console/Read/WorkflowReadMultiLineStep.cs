using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Framework.Workflow.Property;

namespace Framework.Workflow.Steps.Console.Read
{
    internal class WorkflowReadMultiLineStep<TContext> : IWorkflowStep<TContext> where TContext : WorkflowBaseContext
    {
        private readonly Expression<Func<TContext, string>> _propertyPicker;
        private readonly string _endOfInput;

        public WorkflowReadMultiLineStep(Expression<Func<TContext, string>> propertyPicker, string endOfInput)
        {
            _propertyPicker = propertyPicker;
            _endOfInput = endOfInput;
        }

        public Task ExecuteAsync(TContext context)
        {
            var stringBuilder = new StringBuilder();

            var line = string.Empty;
            while (!line.Contains(_endOfInput))
            {
                line = System.Console.ReadLine();

                if (line is null)
                {
                    break;
                }

                if (line.Contains(_endOfInput) && !line.StartsWith(_endOfInput))
                {
                    var endOfLineIndex = line.IndexOf(_endOfInput, StringComparison.Ordinal);
                    stringBuilder.AppendLine(line.Remove(endOfLineIndex));
                } else if (!line.StartsWith(_endOfInput))
                {
                    stringBuilder.AppendLine(line);
                }
            }

            return PropertyValueSetter<TContext, string>.SetAsync(context, stringBuilder.ToString(), _propertyPicker);
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(context.ShouldExecute());
        }
    }
}