using System;
using System.IO;
using System.Text;
using Autofac;
using Framework.Boot.Logger;
using log4net.Config;

namespace Framework.Autofac.Logger
{
    public static class Log4NetConfigurator
    {
        public static Action<ContainerBuilder> Configure()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var module = new Log4NetMiddlewareModule(new Log4NetMiddleware());
            return builder => builder.RegisterModule(module);
        }
        
        public static Action<ContainerBuilder> Configure(string log4NetConfigurationFile)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var module = new Log4NetMiddlewareModule(new Log4NetMiddleware());
            XmlConfigurator.Configure(new FileInfo(log4NetConfigurationFile));
            return builder => builder.RegisterModule(module);
        }
    }
}