using Framework.Boot.Configuration;
using JetBrains.Annotations;
using Workflow;

namespace Framework.Boot;

[UsedImplicitly]
public class BootContext : WorkflowBaseContext, IInternalBootContext
{
    public BootContext(IBootScope<BootContext> bootScope)
    {
        if (bootScope is not IInternalBootScope<BootContext> internalBootScope)
        {
            throw new ArgumentException($"{nameof(bootScope)} does not implement {typeof(IInternalBootScope<BootContext>).FullName}");
        }
        
        ServiceProvider = internalBootScope.ServiceProvider;
    }
        
    public IServiceProvider ServiceProvider { get; }
}