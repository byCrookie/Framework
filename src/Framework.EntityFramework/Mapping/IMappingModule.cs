using Jab;

namespace Framework.EntityFramework.Mapping;

[ServiceProviderModule]
[Transient(typeof(IDataEntityMapper<,>), typeof(DataEntityMapper<,>))]
internal interface IMappingModule
{
    
}