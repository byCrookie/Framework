using System;
using System.Threading.Tasks;
using Framework.Boot;
using Framework.Boot.AssemblyLoad;
using Framework.Boot.Autofac;
using Framework.Boot.Autofac.BuildContainer;
using Framework.Boot.Autofac.ContainerBuilder;
using Framework.Boot.Autofac.ModuleCatalog;
using Framework.Boot.Configuration;
using Framework.Boot.Logger;
using Framework.Boot.Start;
using Framework.Boot.TypeLoad;

namespace Framework.Console.Tests
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var bootScope = BootConfiguration.Configure<BootContext>();

            var bootFlow = bootScope.WorkflowBuilder
                .ThenAsync<IFrameworkConfigurationBootStep<BootContext, FrameworkBootStepOptions>,
                    FrameworkBootStepOptions>(
                    config => { config.ConfigurationFile = "Framework.Console.Test.cfg.xml"; }
                )
                .ThenAsync<IAssemblyBootStep<BootContext>>()
                .ThenAsync<ITypeBootStep<BootContext>>()
                .ThenAsync<IContainerBuildBootStep<BootContext>>()
                .ThenAsync<IModuleCatalogBootStep<BootContext>>()
                .ThenAsync<ILoggerBootStep<BootContext, LoggerBootStepOptions>, LoggerBootStepOptions>(
                    config => { config.Log4NetConfigurationFile = "Framework.Console.Test.cfg.xml"; }
                )
                .ThenAsync<IBuildContainerBootStep<BootContext>>()
                .ThenAsync<IStartBootStep<BootContext>>()
                .Build();

            await bootScope.Container.DisposeAsync().ConfigureAwait(false);
            await bootFlow.RunAsync(new BootContext()).ConfigureAwait(false);
        }
    }
}