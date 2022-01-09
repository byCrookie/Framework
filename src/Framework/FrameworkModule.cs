using Autofac;
using Framework.Autofac;
using Framework.Boot;
using Framework.Hash;
using Framework.Http;
using Framework.Socket;
using Framework.Throttle;
using Framework.Time;
using Framework.Timer;
using Framework.Unique;
using Framework.Xml;
using Workflow.Autofac;

namespace Framework
{
    public class FrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.AddWorkflow();
            
            builder.RegisterModule<AutofacModule>();
            builder.RegisterModule<BootModule>();
            builder.RegisterModule<XmlModule>();
            builder.RegisterModule<SocketModule>();
            builder.RegisterModule<HttpModule>();
            builder.RegisterModule<HashModule>();
            builder.RegisterModule<ThrottleModule>();
            builder.RegisterModule<TimeModule>();
            builder.RegisterModule<TimerModule>();
            builder.RegisterModule<UniqueModule>();
            
            base.Load(builder);
        }
    }
}