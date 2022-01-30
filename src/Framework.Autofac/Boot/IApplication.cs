namespace Framework.Autofac.Boot;

public interface IApplication
{
    Task RunAsync(CancellationToken cancellationToken);
}