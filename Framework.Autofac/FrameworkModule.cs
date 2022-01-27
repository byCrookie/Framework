using Autofac;
using Framework.Autofac.Autofac;
using Framework.Autofac.Boot;
using Framework.Autofac.Hash;
using Framework.Autofac.Http;
using Framework.Autofac.Socket;
using Framework.Autofac.Throttle;
using Framework.Autofac.Time;
using Framework.Autofac.Timer;
using Framework.Autofac.Unique;
using Framework.Autofac.Xml;
using Workflow.Autofac;

namespace Framework.Autofac;

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