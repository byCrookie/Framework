using Framework.Boot.Autofac.ModuleCatalog;
using Workflow.Autofac;

namespace Framework
{
    public class FrameworkModuleCatalog : ModuleCatalog
    {
        public FrameworkModuleCatalog()
        {
            AddRootModule(new WorkflowModule());
            AddRootModule(new FrameworkModule());
        }
    }
}