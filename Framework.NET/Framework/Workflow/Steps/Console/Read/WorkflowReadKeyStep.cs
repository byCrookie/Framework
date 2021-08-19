﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Framework.Workflow.Property;

namespace Framework.Workflow.Steps.Console.Read
{
    internal class WorkflowReadKeyStep<TContext> : IWorkflowStep<TContext> where TContext : WorkflowBaseContext
    {
        private readonly Expression<Func<TContext, ConsoleKeyInfo>> _propertyPicker;

        public WorkflowReadKeyStep(Expression<Func<TContext,ConsoleKeyInfo>> propertyPicker)
        {
            _propertyPicker = propertyPicker;
        }

        public Task ExecuteAsync(TContext context)
        {
            var key = System.Console.ReadKey();
            return PropertyValueSetter<TContext, ConsoleKeyInfo>.SetAsync(context, key, _propertyPicker);
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(context.ShouldExecute());
        }
    }
}