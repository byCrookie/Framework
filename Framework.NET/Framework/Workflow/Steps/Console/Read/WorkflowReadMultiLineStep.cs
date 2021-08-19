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
        private readonly MultiLineOptions _options;

        public WorkflowReadMultiLineStep(Expression<Func<TContext, string>> propertyPicker, MultiLineOptions options)
        {
            _propertyPicker = propertyPicker;
            _options = options;
        }

        public Task ExecuteAsync(TContext context)
        {
            var stringBuilder = new StringBuilder();

            var line = string.Empty;
            while (!line.Contains(_options.EndOfInput))
            {
                line = System.Console.ReadLine();

                if (line is null)
                {
                    break;
                }

                if (line.Contains(_options.EndOfInput) && !line.StartsWith(_options.EndOfInput))
                {
                    if (_options.RemoveEndOfInput)
                    {
                        var endOfLineIndex = line.IndexOf(_options.EndOfInput, StringComparison.Ordinal);
                        stringBuilder.AppendLine(line.Remove(endOfLineIndex));
                    }
                    else
                    {
                        stringBuilder.AppendLine(line);
                    }
                } else if (!line.StartsWith(_options.EndOfInput))
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