using Serilog;

namespace Framework.Boot.Logger
{
    public class LoggerBootStepOptions
    {
        public LoggerBootStepOptions()
        {
            Configuration = new LoggerConfiguration();
        }
        
        public LoggerConfiguration Configuration { get; }
    }
}