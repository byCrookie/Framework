namespace Framework.Boot.Configuration;

internal interface IInternalBootScope<T> : IBootScope<T> where T : BootContext
{
    public IServiceProvider ServiceProvider { get; }
}