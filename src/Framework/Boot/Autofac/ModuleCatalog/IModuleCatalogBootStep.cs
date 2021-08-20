using Framework.Workflow;

namespace Framework.Boot.Autofac.ModuleCatalog
{
    public interface IModuleCatalogBootStep<TContext> : IWorkflowStep<TContext> 
        where TContext : WorkflowBaseContext, IBootContext
    {}
}