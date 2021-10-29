using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Framework.Boot.Configuration;

namespace Framework.Boot
{
    public interface IBootContext
    {
        IContainer Container { get; set; }
        IList<Action<ContainerBuilder>> RegistrationActions { get; set; }
        ILifetimeScope BootLifetimeScope { get; set; }
        ILifetimeScope LifetimeScope { get; set; }
        IEnumerable<Assembly> Assemblies { get; set; }
        IEnumerable<Type> Types { get; set; }
        FrameworkConfiguration FrameworkConfiguration { get; set; }
    }
}