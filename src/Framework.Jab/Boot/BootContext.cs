using JetBrains.Annotations;
using Workflow;

namespace Framework.Jab.Boot;

[UsedImplicitly]
public class BootContext : WorkflowBaseContext, IBootContext
{
    public BootContext(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }
        
    public IServiceProvider ServiceProvider { get; }
}