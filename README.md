# Framework.NET

## About
Contains various components to build .NET apps.

## Features

* Building workflows (mainly Console-Apps)
  * And prebuilt bootsteps (autofac, log4net)
* Additional extensions for lists, enums usw.
* Wrappers around .NET classes (XML, DateTime, GUID usw.)
* Throttler for parallel task execution using rate-limits
* Timers

## How to use

:warning: **Packages**: Packages are not working at the moment, please build the project yourself using the sourcecode

1. Reference https://nuget.pkg.github.com/byCrookie/index.json in your nuget.config or download the package
3. Use username byCrookie and password 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
4. Add the package to your project

## Contributing / Issues
All contributions are welcome! If you have any issues or feature requests, either implement it yourself or create an issue, thank you.

## Donation
If you like this project, feel free to donate and support the further development. Thank you.

Bitcoin (BTC) Donations using Bitcoin (BTC) Network -> 14vZ2rRTEWXhvfLrxSboTN15k5XuRL1AHq

## Docs

### Bootstrapping Application
Use prebuilt bootstep context and steps to boot application
using autofac, log4net. Or just make your one bootrapper.

```C#
var bootScope = BootConfiguration.Configure<BootContext>(new List<Module> {new BootstrappingModule()});
var bootFlow = bootScope.WorkflowBuilder
    .ThenAsync<IFrameworkConfigurationBootStep<BootContext, FrameworkBootStepOptions>,
        FrameworkBootStepOptions>(
        config => { config.ConfigurationFile = "TypeCode.Console.cfg.xml"; }
    )
    .ThenAsync<IAssemblyBootStep<BootContext>>()
    .ThenAsync<ITypeBootStep<BootContext>>()
    .ThenAsync<IContainerBuildBootStep<BootContext>>()
    .ThenAsync<IModuleCatalogBootStep<BootContext>>()
    .ThenAsync<ILoggerBootStep<BootContext, LoggerBootStepOptions>, LoggerBootStepOptions>(
        config => { config.Log4NetConfigurationFile = "TypeCode.Console.cfg.xml"; }
    )
    .ThenAsync<IBuildContainerBootStep<BootContext>>()
    .ThenAsync<IAssemblyLoadBootStep<BootContext>>()
    .ThenAsync<IStartBootStep<BootContext>>()
    .Build();

await bootScope.Container.DisposeAsync().ConfigureAwait(false);
await bootFlow.RunAsync(new BootContext()).ConfigureAwait(false);
```

