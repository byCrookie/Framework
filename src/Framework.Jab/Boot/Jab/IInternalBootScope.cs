namespace Framework.Jab.Boot.Jab;

internal interface IInternalBootScope<T> : IBootScope<T> where T : BootContext
{
    public IServiceProvider ServiceProvider { get; }
}