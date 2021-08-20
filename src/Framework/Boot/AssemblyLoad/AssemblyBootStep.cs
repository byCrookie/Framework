using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Framework.Workflow;

namespace Framework.Boot.AssemblyLoad
{
    internal class AssemblyBootStep<TContext> : IAssemblyBootStep<TContext>
        where TContext : WorkflowBaseContext, IBootContext
    {
        public Task ExecuteAsync(TContext context)
        {
            var assemblyRootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (assemblyRootPath is null)
            {
                throw new ArgumentNullException($"{nameof(assemblyRootPath)} is null", nameof(assemblyRootPath));
            }

            var assemblyPaths = Directory.GetFiles(assemblyRootPath)
                .Where(file => context.FrameworkConfiguration.Framework.Autofac.AssemblySelctor
                .Any(selector => Regex.IsMatch(Path.GetFileName(file), selector)));

            var assemblies = new ConcurrentBag<Assembly>();

            Parallel.ForEach(assemblyPaths, assemblyPath => LoadAssembly(assemblies, assemblyPath));

            var bootContext = context as IBootContext;
            bootContext.Assemblies = assemblies;
            return Task.CompletedTask;
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(true);
        }

        private static void LoadAssembly(ConcurrentBag<Assembly> assemblies, string assemblyPath)
        {
            if (File.Exists(assemblyPath))
            {
                var assembly = Assembly.LoadFrom(assemblyPath);
                assemblies.Add(assembly);
            }
        }
    }
}