using System.Collections.Generic;
using Autofac.Core;

namespace Framework.Boot.Autofac.Registration
{
    public class AutofacBuilder
    {
        public AutofacBuilder()
        {
            ModuleCatalogs = new List<ModuleCatalog>();
            Modules = new List<IModule>();
        }

        public AutofacBuilder AddModule(IModule module)
        {
            Modules.Add(module);
            return this;
        }
        
        public AutofacBuilder AddModuleCatalog(ModuleCatalog moduleCatalog)
        {
            ModuleCatalogs.Add(moduleCatalog);
            return this;
        }

        public List<IModule> Modules { get; }

        public List<ModuleCatalog> ModuleCatalogs { get; }
    }
}