using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Workflow;

namespace Framework.Boot.Autofac.ModuleCatalog
{
    internal class ModuleCatalogBootStep<TContext> : IModuleCatalogBootStep<TContext>
        where TContext : WorkflowBaseContext, IBootContext
    {
        public Task ExecuteAsync(TContext context)
        {
            var bootContext = context as IBootContext;

            var catalogs = bootContext.Types
                .Where(type => type.IsAssignableTo<ModuleCatalog>()
                               && type != typeof(ModuleCatalog));

            foreach (var module in catalogs
                .Select(catalog => Activator.CreateInstance(catalog) as ModuleCatalog)
                .Select(catalogInstance => catalogInstance?.Modules ?? new List<IModule>())
                .SelectMany(modules => modules))
            {
                context.RegistrationActions.Add(builder => builder.RegisterModule(module));
            }

            context.RegistrationActions.Add(builder => builder.RegisterModule<FrameworkModule>());

            return Task.CompletedTask;
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }
    }
}