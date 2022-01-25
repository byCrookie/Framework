namespace Framework.Extensions.Cancel;

public static class CancellationTokenExtensions
{
    public static Task AsTaskAsync(this CancellationToken token)
    {
        return new Task(() => throw new InvalidOperationException(), token);
    }

    public static Task<TResult> AsTaskAsync<TResult>(this CancellationToken token)
    {
        return new Task<TResult>(() => throw new InvalidOperationException(), token);
    }
}