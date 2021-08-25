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

1. Reference https://nuget.pkg.github.com/byCrookie/index.json in your nuget.config or download the package
2. If step 1 fails, you have to download the sources, build the project and use the packged nuget package 
3. Use username byCrookie and password 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
4. Add the package to your project

## Contributing / Issues
All contributions are welcome! If you have any issues or feature requests, either implement it yourself or create an issue, thank you.

## Donation
If you like this project, feel free to donate and support the further development. Thank you.

Bitcoin (BTC) Donations using Bitcoin (BTC) Network -> 14vZ2rRTEWXhvfLrxSboTN15k5XuRL1AHq

## Docs

### Workflow
Workflows make it easy to create a console application flow. Workflow has various methods from reading multiline user content to using custom built steps.

#### Example
```C#
var workflow = _workflowBuilder
    .WriteLine(context => $@"{Cuts.Point()} Input type")
    .Then(context => context.TypeName, context => Console.ReadLine())
    .While(context => !_typeProvider.HasByName(context.TypeName.Trim()), whileFlow => whileFlow
        .WriteLine(context => $@"{Cuts.Point()} Type not found")
        .WriteLine(context => $@"{Cuts.Point()} Please input input type")
        .Then(context => context.TypeName, context => Console.ReadLine())
        .IfFlow(context => string.IsNullOrEmpty(context.TypeName), ifFlow => ifFlow
            .WriteLine(context => $@"{Cuts.Point()} Press enter to exit or space to continue")
            .IfFlow(context => Console.ReadKey().Key == ConsoleKey.Enter, ifFlowLeave => ifFlowLeave
                .StopAsync()
            )
        )
    )
    .Then(context => context.SelectedTypes, context => _typeProvider.TryGetByName(context.TypeName.Trim()).ToList())
    .ThenAsync<IMultipleTypeSelectionStep<BuilderContext>>()
    .Stop(c => !c.SelectedType.IsClass, c => Console.WriteLine($@"{Cuts.Point()} Type has to be a class"))
    .Then(context => context.BuilderCode, context => GenerateBuilderCode(context.SelectedType))
    .Build();

var workflowContext = await workflow.RunAsync(new BuilderContext()).ConfigureAwait(false);
return workflowContext.BuilderCode;
```

#### Custom Step

```C#
var workflow = _workflowEvaluationBuilder
    .ThenAsync<ISelectionStep<UnitTestDependencyEvaluationContext, SelectionStepOptions>,
        SelectionStepOptions>(config =>
        {
            config.Selections = new List<string>
            {
                "Input type by name",
                "Input dependencies manually (,)"
            };
        }
    )
```

```C#
internal class SelectionStep<TContext, TOptions> :
        ISelectionStep<TContext, TOptions>
        where TContext : WorkflowBaseContext, ISelectionContext
    {
        private readonly IWorkflowBuilder<SelectionContext> _workflowBuilder;
        private SelectionStepOptions _options;

        public SelectionStep(IWorkflowBuilder<SelectionContext> workflowBuilder)
        {
            _workflowBuilder = workflowBuilder;
        }

        public async Task ExecuteAsync(TContext context)
        {
            var selectionContext = new SelectionContext();

            var workflow = _workflowBuilder
                .While(c => c.Selection == 0 || c.Selection > _options.Selections.Count, whileFlow => whileFlow
                    .WriteLine(_ => $@"{Cuts.Medium()}")
                    .WriteLine(_ => $@"{Cuts.Heading()} Select an option")
                    .WriteLine(_ => CreateSelectionMenu(_options.Selections))
                    .ReadLine(c => c.Input)
                    .IfFlow(c => string.IsNullOrEmpty(c.Input.Trim()), ifFlow => ifFlow
                        .WriteLine(_ => $@"{Cuts.Point()} Press enter to exit or space to continue")
                        .IfFlow(_ => Console.ReadKey().Key == ConsoleKey.Enter, ifFlowLeave => ifFlowLeave
                            .StopAsync(context)
                        )
                    )
                    .Then(c => c.Selection, c => Convert.ToInt16(c.Input.Trim()))
                    .If(c => c.Selection > _options.Selections.Count || c.Selection < 1, _ => Console.WriteLine($@"{Cuts.Point()} Option is not valid"))
                )
                .Build();

            var workflowContext = await workflow.RunAsync(selectionContext).ConfigureAwait(false);
            context.Selection = workflowContext.Selection;
        }

        private static string CreateSelectionMenu(IReadOnlyList<string> selections)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($@"{Cuts.Medium()}");
            for (var index = 0; index < selections.Count; index++)
            {
                stringBuilder.AppendLine($@"{Cuts.Point()} {index + 1} - {selections[index]}");
            }

            stringBuilder.Append($@"{Cuts.Medium()}");
            return stringBuilder.ToString();
        }

        public Task<bool> ShouldExecuteAsync(TContext context)
        {
            return Task.FromResult(context.ShouldExecute());
        }

        public void SetOptions(TOptions options)
        {
            _options = options as SelectionStepOptions;
        }
    }
```

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

