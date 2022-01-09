using Serilog;

namespace Framework.Boot.Logger
{
    public abstract class LoggerBootStepOptions
    {
        protected LoggerBootStepOptions()
        {
            Configuration = new LoggerConfiguration();
        }
        
        public LoggerConfiguration Configuration { get; }
    }
}