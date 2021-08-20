using Framework.Boot.Autofac.ModuleCatalog;

namespace Framework.Console.Tests
{
    public class FrameworkTestModuleCatalog : ModuleCatalog
    {
        public FrameworkTestModuleCatalog()
        {
            AddRootModule(new FrameworkConsoleTestModule());
        }
    }
}