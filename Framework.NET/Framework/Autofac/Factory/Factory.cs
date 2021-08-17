using System;
using Autofac;

namespace Framework.Autofac.Factory
{
    internal class Factory : IFactory
    {
        private readonly IComponentContext _componentContext;

        public Factory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public T Create<T>()
        {
            return _componentContext.Resolve<T>();
        }
    }
    
    internal class Factory<T> : IFactory<T>
    {
        private readonly Func<T> _factory;

        public Factory(Func<T> factory)
        {
            _factory = factory;
        }

        public T Create()
        {
            return _factory();
        }
    }
    
    internal class Factory<TParameter, T> : IFactory<TParameter, T>
    {
        private readonly Func<TParameter, T> _factory;

        public Factory(Func<TParameter, T> factory)
        {
            _factory = factory;
        }

        public T Create(TParameter parameter)
        {
            return _factory(parameter);
        }
    }
    
    internal class Factory<TParameter1, TParameter2, T> : IFactory<TParameter1, TParameter2, T>
    {
        private readonly Func<TParameter1, TParameter2, T> _factory;

        public Factory(Func<TParameter1, TParameter2, T> factory)
        {
            _factory = factory;
        }

        public T Create(TParameter1 parameter1, TParameter2 parameter2)
        {
            return _factory(parameter1, parameter2);
        }
    }
    
    internal class Factory<TParameter1, TParameter2, TParameter3, T> : IFactory<TParameter1, TParameter2, TParameter3, T>
    {
        private readonly Func<TParameter1, TParameter2, TParameter3, T> _factory;

        public Factory(Func<TParameter1, TParameter2, TParameter3, T> factory)
        {
            _factory = factory;
        }

        public T Create(TParameter1 parameter1, TParameter2 parameter2, TParameter3 parameter3)
        {
            return _factory(parameter1, parameter2, parameter3);
        }
    }
    
    internal class Factory<TParameter1, TParameter2, TParameter3, TParameter4, T> : IFactory<TParameter1, TParameter2, TParameter3, TParameter4, T>
    {
        private readonly Func<TParameter1, TParameter2, TParameter3, TParameter4, T> _factory;

        public Factory(Func<TParameter1, TParameter2, TParameter3, TParameter4, T> factory)
        {
            _factory = factory;
        }

        public T Create(TParameter1 parameter1, TParameter2 parameter2, TParameter3 parameter3, TParameter4 parameter4)
        {
            return _factory(parameter1, parameter2, parameter3, parameter4);
        }
    }
    
    internal class Factory<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, T> : IFactory<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, T>
    {
        private readonly Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, T> _factory;

        public Factory(Func<TParameter1, TParameter2, TParameter3, TParameter4, TParameter5, T> factory)
        {
            _factory = factory;
        }

        public T Create(TParameter1 parameter1, TParameter2 parameter2, TParameter3 parameter3, TParameter4 parameter4, TParameter5 parameter5)
        {
            return _factory(parameter1, parameter2, parameter3, parameter4, parameter5);
        }
    }
}