namespace Framework.Boot;

public interface IApplication
{
    Task RunAsync(CancellationToken cancellationToken);
}