using Autofac;

namespace Framework.Autofac.Factory
{
    internal class KeyedFactory : IKeyedFactory
    {
        private readonly IComponentContext _componentContext;

        public KeyedFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public T Create<T, TKey>(TKey key)
        {
            return _componentContext.ResolveKeyed<T>(key);
        }
    }
    
    internal class KeyedFactory<T> : IKeyedFactory<T>
    {
        private readonly IComponentContext _componentContext;

        public KeyedFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public T Create<TKey>(TKey key)
        {
            return _componentContext.ResolveKeyed<T>(key);
        }
    }
}