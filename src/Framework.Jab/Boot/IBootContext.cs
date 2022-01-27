namespace Framework.Jab.Boot;

public interface IBootContext
{
    DefaultServiceProvider ServiceProvider { get; set; }
}