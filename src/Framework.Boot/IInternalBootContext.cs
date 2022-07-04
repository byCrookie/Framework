namespace Framework.Boot;

public interface IInternalBootContext : IBootContext
{
    IServiceProvider ServiceProvider { get; }
}