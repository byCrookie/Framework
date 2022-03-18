using System.Diagnostics;
using Framework.Validation;
using Serilog;

namespace Framework.Timer;

public class IntervalTimer : IIntervalTimer
{
    private static readonly Stopwatch Stopwatch = new();
    private Func<Task> _callback = () => Task.CompletedTask;
    private TimeSpan _interval;

    public IIntervalTimer Run(TimeSpan interval, Func<Task> callback)
    {
        _interval = interval;
        _callback = callback;
        Stopwatch.Start();
        return this;
    }

    public Task CheckAsync()
    {
        Validate.NotNull(_interval, nameof(_interval));
        Validate.NotNull(_callback, nameof(_callback));
            
        if (Stopwatch.Elapsed >= _interval)
        {
            Log.Debug("Execute interval {0} timer after {1}", _interval, Stopwatch.Elapsed);
            _callback();
            Stopwatch.Restart();
        }
            
        return Task.CompletedTask;
    }
}