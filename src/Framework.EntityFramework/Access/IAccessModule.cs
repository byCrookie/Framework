using Framework.EntityFramework.Access.Session;
using Jab;

namespace Framework.EntityFramework.Access;

[ServiceProviderModule]
[Import(typeof(ISessionModule))]
public interface IAccessModule
{
}