using System.Collections.Generic;
using Autofac.Core;

namespace Framework.Boot.Autofac
{
    public class ModuleCatalog
    {
        protected ModuleCatalog()
        {
            Modules = new List<IModule>();
        }

        public List<IModule> Modules { get; }

        protected void AddRootModule(IModule module)
        {
            Modules.Add(module);
        }
    }
}