using Jab;

namespace Framework.EntityFramework.Access.Session;

[ServiceProviderModule]
[Singleton(typeof(ISession), typeof(Session))]
internal interface ISessionModule
{
}