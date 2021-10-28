using Workflow;

namespace Framework.Boot.Autofac.ModuleCatalog
{
    public interface IModuleCatalogBootStep<in TContext> : IWorkflowStep<TContext> 
        where TContext : WorkflowBaseContext, IBootContext
    {}
}