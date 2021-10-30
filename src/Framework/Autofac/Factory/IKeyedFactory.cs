namespace Framework.Autofac.Factory
{
    public interface IKeyedFactory
    {
        public T Create<T, TKey>(TKey key);
    }
    
    public interface IKeyedFactory<out T>
    {
        T Create<TKey>(TKey key);
    }
}