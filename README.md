# Framework
Contains various components to build .NET apps.

## Features

### Framework

* Additional extensions for lists, enums usw.
* Wrappers around .NET classes (XML, DateTime)
* BackgroundTask

### Framework.Boot

* Bootsteps for
  * logging (serilog)

### Framework.EntityFramework

* Mapping interfaces between data <-> entity
* Entity interface
* Query interfaces
* Session interface

## Dependencies & Acknowledgements
This project relies on following packages:
* Workflow: https://github.com/byCrookie/Workflow
* BuildSdk https://github.com/byCrookie/BuildSdk
* DependencyInjection https://github.com/byCrookie/DependencyInjection
* Jab Dependency-Injection https://github.com/pakrym/jab

## How to use

### Local Nuget Source
* Download the nuget package
* Add download path as nuget source
* Reference the package in your project

### Remote Nuget-Source

Add remote nuget source to your nuget.config:

* {Token}: Z2hwX1hybmFLaVIyTm1zaGVWRVpqMjVLbHZsNTBjdldKYjMzQ2hPeQ== -> Convert Base64 back to Text First
* Execute: dotnet nuget add source --username byCrookie --password {Token} --name byCrookie_Github --store-password-in-clear-text https://nuget.pkg.github.com/byCrookie/index.json

### Dev

* Clone the git repository
* Change the "localPackages" path in the nuget.config

## Contributing / Issues
All contributions are welcome! If you have any issues or feature requests, either implement it yourself or create an issue, thank you.

## Donation
If you like this project, feel free to donate and support further development. Thank you.

* Bitcoin (BTC) Donations using Bitcoin (BTC) Network -> bc1qygqya2w3hgpvy8hupctfkv5x06l69ydq4su2e2
* Ethereum (ETH) Donations using Ethereum (ETH) Network -> 0x1C0416cC1DDaAEEb3017D4b8Dcd3f0B82f4d94C1

## Docs

### Boot

```C#
public static Task BootAsync()
{
    var serviceProvider = new TypeCodeWpfServiceProvider();
    var bootScope = BootConfiguration.Configure<BootContext>(serviceProvider);

    var bootFlow = bootScope.WorkflowBuilder
        .ThenAsync<ILoggerBootStep<BootContext, LoggerBootStepOptions>, LoggerBootStepOptions>(
            options => LoggerConfigurationProvider.Create(options)
        )
        .ThenAsync<ISetupWpfApplicationStep<BootContext>>()
        .ThenAsync<IStartBootStep<BootContext>>()
        .Build();

    return bootFlow.RunAsync(new BootContext(bootScope));
}
```

