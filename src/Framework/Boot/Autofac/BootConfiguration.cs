using System.Collections.Generic;
using System.Linq;
using Autofac;
using Workflow;

namespace Framework.Boot.Autofac
{
    public static class BootConfiguration
    {
        public static BootScope<T> Configure<T>() where T : WorkflowBaseContext
        {
            return Configure<T>(Enumerable.Empty<Module>());
        }

        public static BootScope<T> Configure<T>(IEnumerable<Module> modules) where T : WorkflowBaseContext
        {
            var builder = new global::Autofac.ContainerBuilder();
            builder.RegisterModule<FrameworkModule>();

            foreach (var module in modules)
            {
                builder.RegisterModule(module);
            }
            
            var container = builder.Build();
            var workflowBuilder = container.Resolve<IWorkflowBuilder<T>>();
            return new BootScope<T>
            {
                Container = container,
                WorkflowBuilder = workflowBuilder
            };
        }
    }
}