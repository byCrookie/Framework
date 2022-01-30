namespace Framework.Jab.Boot;

public interface IInternalBootContext : IBootContext
{
    IServiceProvider ServiceProvider { get; }
}