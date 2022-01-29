namespace Framework.Jab.Boot;

public interface IBootContext
{
    IServiceProvider ServiceProvider { get; set; }
}