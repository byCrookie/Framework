using Workflow;

namespace Framework.Jab.Boot.Jab;

interface IInternalBootScope<T> : IBootScope<T> where T : WorkflowBaseContext
{
    public IServiceProvider ServiceProvider { get; }
}