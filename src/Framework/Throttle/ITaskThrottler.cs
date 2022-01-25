namespace Framework.Throttle;

public interface ITaskThrottler
{
    Task<IEnumerable<T>> ThrottleAsync<T>(IEnumerable<Func<Task<T>>> tasks, ThrottleLimit throttleLimit,
        CancellationToken cancellationToken);

    Task ThrottleAsync(IEnumerable<Func<Task>> tasks, ThrottleLimit throttleLimit, CancellationToken cancellationToken);
}