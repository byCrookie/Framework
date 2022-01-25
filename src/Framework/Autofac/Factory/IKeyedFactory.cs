namespace Framework.Autofac.Factory;

public interface IKeyedFactory
{
    public T Create<T, TKey>(TKey key)  where T : notnull where TKey : notnull;
}
    
public interface IKeyedFactory<out T> where T : notnull
{
    T Create<TKey>(TKey key) where TKey : notnull;
}