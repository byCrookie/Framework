using System.IO;
using System.Text;
using Autofac;
using Framework.Boot.Logger;
using log4net.Config;

namespace Framework.Autofac.Logger
{
    internal static class Log4NetConfigurator
    {
        public static void Configure(ContainerBuilder containerBuilder, string log4NetConfigurationFile)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var module = new Log4NetMiddlewareModule(new Log4NetMiddleware());
            XmlConfigurator.Configure(new FileInfo(log4NetConfigurationFile));
            containerBuilder.RegisterModule(module);
        }
    }
}