using System.Collections.Generic;
using Autofac.Core;

namespace Framework.Boot.Autofac.ModuleCatalog
{
    public class ModuleCatalog
    {
        public ModuleCatalog()
        {
            Modules = new List<IModule>();
        }

        public IList<IModule> Modules { get; set; }

        protected void AddRootModule(IModule module)
        {
            Modules.Add(module);
        }
    }
}