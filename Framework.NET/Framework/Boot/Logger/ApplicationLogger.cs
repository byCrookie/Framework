using log4net.Core;

namespace Framework.Boot.Logger
{
    internal class ApplicationLogger : LogImpl, IApplicationLogger
    {
        public ApplicationLogger(ILogger logger) : base(logger)
        { }
    }
}