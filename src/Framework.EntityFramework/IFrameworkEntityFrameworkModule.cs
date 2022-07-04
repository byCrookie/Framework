using Framework.EntityFramework.Access;
using Framework.EntityFramework.Mapping;
using Jab;

namespace Framework.EntityFramework;

[ServiceProviderModule]
[Import(typeof(IAccessModule))]
[Import(typeof(IMappingModule))]
public interface IFrameworkEntityFrameworkModule
{
    
}