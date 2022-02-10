namespace Framework.Jab.Boot;

public interface IApplication<in TContext> where TContext : IBootContext
{
    Task RunAsync(TContext context, CancellationToken cancellationToken);
}