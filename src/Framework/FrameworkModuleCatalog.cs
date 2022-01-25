using Framework.Boot.Autofac;

namespace Framework;

public class FrameworkModuleCatalog : ModuleCatalog
{
    public FrameworkModuleCatalog()
    {
        AddRootModule(new FrameworkModule());
    }
}