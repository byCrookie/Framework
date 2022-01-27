using Autofac.Core;

namespace Framework.Autofac.Boot.Autofac.Registration;

public class AutofacBuilder
{
    public AutofacBuilder()
    {
        Modules = new List<IModule>();
    }

    public AutofacBuilder AddModule(IModule module)
    {
        Modules.Add(module);
        return this;
    }

    public List<IModule> Modules { get; }
}