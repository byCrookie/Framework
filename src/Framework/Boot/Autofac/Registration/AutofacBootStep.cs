using Autofac;
using Autofac.Core;
using Workflow;

namespace Framework.Boot.Autofac.Registration;

internal class AutofacBootStep<TContext, TOptions> : IAutofacBootStep<TContext, TOptions>
    where TContext : WorkflowBaseContext, IBootContext
{
    private AutofacBootStepOptions? _bootStepOptions;

    public Task ExecuteAsync(TContext context)
    {
        foreach (var module in _bootStepOptions?.Autofac.ModuleCatalogs
                     .Select(catalogInstance => catalogInstance.Modules)
                     .SelectMany(modules => modules)
                     .Concat(_bootStepOptions.Autofac.Modules) ?? new List<IModule>())
        {
            context.RegistrationActions.Add(builder => builder.RegisterModule(module));
        }

        context.RegistrationActions.Add(builder => builder.RegisterModule<FrameworkModule>());

        return Task.CompletedTask;
    }

    public Task<bool> ShouldExecuteAsync(TContext context)
    {
        return Task.FromResult(true);
    }

    public void SetOptions(TOptions options)
    {
        _bootStepOptions = options as AutofacBootStepOptions;
    }
}