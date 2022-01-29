using Workflow;

namespace Framework.Jab.Boot;

public class BootContext : WorkflowBaseContext, IBootContext
{
    public BootContext(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }
        
    public IServiceProvider ServiceProvider { get; set; }
}