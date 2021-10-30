using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Framework.Boot.Configuration;
using Workflow;

namespace Framework.Boot
{
    public class BootContext : WorkflowBaseContext, IBootContext
    {
        public BootContext(IContainer container, ILifetimeScope bootLifetimeScope)
        {
            Container = container;
            BootLifetimeScope = bootLifetimeScope;
            
            RegistrationActions = new List<Action<ContainerBuilder>>();
            Assemblies = new List<Assembly>();
            Types = new List<Type>();
        }
        
        public IContainer Container { get; set; }
        public IList<Action<ContainerBuilder>> RegistrationActions { get; set; }
        public ILifetimeScope BootLifetimeScope { get; set; }
        public ILifetimeScope LifetimeScope { get; set; }
        public IEnumerable<Assembly> Assemblies { get; set; }
        public IEnumerable<Type> Types { get; set; }
        public FrameworkConfiguration FrameworkConfiguration { get; set; }
    }
}