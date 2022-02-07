using Autofac;
using Autofac.Core;

namespace Framework.Autofac.Boot.Autofac.Registration;

internal class AutofacBootStep<TContext, TOptions> : IAutofacBootStep<TContext, TOptions>
    where TContext : BootContext
{
    private AutofacBootStepOptions? _bootStepOptions;

    public Task ExecuteAsync(TContext context)
    {
        foreach (var module in _bootStepOptions?.Autofac.Modules ?? new List<IModule>())
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