using System.Collections.Generic;

namespace Framework.Boot.Configuration
{
    public class Autofac 
    {
        public List<string> AssemblySelctor { get; set; }
    }
    
    public class Framework {
        public Autofac Autofac { get; set; }
    }
    
    public class FrameworkConfiguration {
        public Framework Framework { get; set; }
    }
}