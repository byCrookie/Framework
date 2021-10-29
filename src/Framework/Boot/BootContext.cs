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
        public IContainer Container { get; set; }
        public ContainerBuilder CointainerBuilder { get; set; }
        public IEnumerable<Assembly> Assemblies { get; set; }
        public IEnumerable<Type> Types { get; set; }
        public FrameworkConfiguration FrameworkConfiguration { get; set; }
    }
}