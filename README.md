# Framework
Contains various components to build .NET apps.

## Features

* Building workflows (mainly Console-Apps)
  * And prebuilt bootsteps (autofac, jab, serilog)
* Additional extensions for lists, enums usw.
* Wrappers around .NET classes (XML, DateTime, GUID usw.)
* Throttler for parallel task execution using rate-limits
* Timers

## Dependencies & Acknowledgements
This project relies on following to packages
* Workflow: https://github.com/byCrookie/Workflow
* BuildSdk https://github.com/byCrookie/BuildSdk
* Jab Dependency-Injection https://github.com/pakrym/jab

## How to use

### Local Nuget Source
* Download the nuget package 
* Add download path as nuget source
* Reference the package in your project

### Remote Nuget-Source

Add the following remote nuget source to your nuget.config file.

```xml
<configuration>

  <packageSources>
    <add key="github" value="https://nuget.pkg.github.com/byCrookie/index.json" />
  </packageSources>

  <packageSourceCredentials>
    <github>
      <add key="Username" value="byCrookie" />
      <add key="ClearTextPassword" value="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" />
    </github>
  </packageSourceCredentials>

</configuration>
```

### Dev

* Clone the git repository
* Change the "localPackages" path in the nuget.config

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

