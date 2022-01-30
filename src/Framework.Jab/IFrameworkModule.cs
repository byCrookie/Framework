using Framework.Jab.Boot;
using Framework.Jab.Hash;
using Framework.Jab.Http;
using Framework.Jab.Jab;
using Framework.Jab.Socket;
using Framework.Jab.Throttle;
using Framework.Jab.Time;
using Framework.Jab.Timer;
using Framework.Jab.Unique;
using Framework.Jab.Xml;
using Jab;
using Workflow.Jab;

namespace Framework.Jab;

[ServiceProviderModule]
[Import(typeof(IJabModule))]
[Import(typeof(IWorkflowModule))]
[Import(typeof(IBootModule))]
[Import(typeof(IXmlModule))]
[Import(typeof(ISocketModule))]
[Import(typeof(IHttpModule))]
[Import(typeof(IHashModule))]
[Import(typeof(IThrottleModule))]
[Import(typeof(ITimeModule))]
[Import(typeof(ITimerModule))]
[Import(typeof(IUniqueModule))]
public interface IFrameworkModule
{
}