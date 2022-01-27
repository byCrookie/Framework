using Workflow;

namespace Framework.Jab.Boot;

public class BootContext : WorkflowBaseContext, IBootContext
{
    public BootContext(DefaultServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }
        
    public DefaultServiceProvider ServiceProvider { get; set; }
}