namespace Framework.Background;

public class BackgroundTask
{
    private Task? _timerTask;
    private readonly PeriodicTimer _timer;
    private readonly Func<CancellationToken, Task> _callback;
    private readonly CancellationTokenSource _cts;

    public BackgroundTask(TimeSpan period, Func<CancellationToken, Task> callback, CancellationTokenSource cts)
    {
        _timer = new PeriodicTimer(period);
        _callback = callback;
        _cts = cts;
    }

    public void Start()
    {
        _timerTask = RunAsync();
    }

    private async Task RunAsync()
    {
        try
        {
            while (await _timer.WaitForNextTickAsync(_cts.Token).ConfigureAwait(true))
            {
#pragma warning disable CS4014
                _callback(_cts.Token);
#pragma warning restore CS4014
            }
        }
        catch (OperationCanceledException)
        {
        }
    }

    public async Task StopAsync()
    {
        if (_timerTask is null)
        {
            return;
        }

        _cts.Cancel();
        await _timerTask.ConfigureAwait(true);
        _cts.Dispose();
    }
}