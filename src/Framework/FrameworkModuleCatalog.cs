using Framework.Boot.Autofac.ModuleCatalog;

namespace Framework
{
    public class FrameworkModuleCatalog : ModuleCatalog
    {
        public FrameworkModuleCatalog()
        {
            AddRootModule(new FrameworkModule());
        }
    }
}