using Autofac;
using Workflow;

namespace Framework.Boot.Autofac
{
    public class BootScope<T> where T : WorkflowBaseContext
    {
        public IContainer Container { get; set; }
        public IWorkflowBuilder<T> WorkflowBuilder { get; set; }
    }
}