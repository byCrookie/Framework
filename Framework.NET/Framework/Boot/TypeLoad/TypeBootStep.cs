using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Framework.Extensions.List;
using Framework.Workflow;

namespace Framework.Boot.TypeLoad
{
    internal class TypeBootStep<TContext> : ITypeBootStep<TContext>
        where TContext : WorkflowBaseContext, IBootContext
    {
        private readonly ITypeEvaluator _typeEvaluator;

        public TypeBootStep(ITypeEvaluator typeEvaluator)
        {
            _typeEvaluator = typeEvaluator;
        }

        public Task ExecuteAsync(TContext context)
        {
            var bootContext = context as IBootContext;
            var types = new ConcurrentBag<Type>();
            
            Parallel.ForEach(bootContext.Assemblies,
                assembly => _typeEvaluator.EvaluateTypes(assembly)
                    .ForEach(type => types.Add(type)));
            
            bootContext.Types = types;
            return Task.CompletedTask;
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }
    }
}