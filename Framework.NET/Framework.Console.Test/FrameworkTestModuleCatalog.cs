using Framework.Boot.Autofac.ModuleCatalog;

namespace Framework.Console.Test
{
    public class FrameworkTestModuleCatalog : ModuleCatalog
    {
        public FrameworkTestModuleCatalog()
        {
            AddRootModule(new FrameworkConsoleTestModule());
        }
    }
}