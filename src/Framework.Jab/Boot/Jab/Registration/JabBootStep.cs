using Workflow;

namespace Framework.Jab.Boot.Jab.Registration;

internal class JabBootStep<TContext, TOptions> : IJabBootStep<TContext, TOptions>
    where TContext : WorkflowBaseContext, IBootContext
{
    private JabBootStepOptions _bootStepOptions;

    public JabBootStep(JabBootStepOptions bootStepOptions)
    {
        _bootStepOptions = bootStepOptions;
    }

    public Task ExecuteAsync(TContext context)
    {
        context.ServiceProvider = _bootStepOptions.Jab.ServiceProvider;

        return Task.CompletedTask;
    }

    public Task<bool> ShouldExecuteAsync(TContext context)
    {
        return Task.FromResult(true);
    }

    public void SetOptions(TOptions? options)
    {
        _bootStepOptions = options as JabBootStepOptions ?? new JabBootStepOptions();
    }
}