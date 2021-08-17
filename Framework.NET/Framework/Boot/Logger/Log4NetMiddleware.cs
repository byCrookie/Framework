using System;
using System.Linq;
using System.Reflection;
using Autofac.Core;
using Autofac.Core.Resolving.Pipeline;
using log4net;

namespace Framework.Boot.Logger
{
    internal class Log4NetMiddleware : IResolveMiddleware
    {
        public void Execute(ResolveRequestContext context, Action<ResolveRequestContext> next)
        {
            context.ChangeParameters(context.Parameters.Union(
                new[]
                {
                    new ResolvedParameter(
                        (p, _) => p.ParameterType == typeof(ILog),
                        (p, _) => LogManager.GetLogger(p.Member.DeclaringType)
                    ),
                }));
            
            next(context);
            
            if (context.NewInstanceActivated)
            {
                var instanceType = context.Instance?.GetType();
                
                var properties = instanceType?.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.PropertyType == typeof(ILog) && p.CanWrite && p.GetIndexParameters().Length == 0);
                
                foreach (var propToSet in properties ?? Enumerable.Empty<PropertyInfo>())
                {
                    propToSet.SetValue(context.Instance, LogManager.GetLogger(instanceType), null);
                }
            }
        }

        public PipelinePhase Phase => PipelinePhase.ParameterSelection;
    }
}