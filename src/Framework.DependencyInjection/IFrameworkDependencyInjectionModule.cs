using Framework.DependencyInjection.Factory;
using Jab;

namespace Framework.DependencyInjection;

[ServiceProviderModule]
[Import(typeof(IFactoryModule))]
public interface IFrameworkDependencyInjectionModule
{
    
}