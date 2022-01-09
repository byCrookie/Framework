using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Framework.Validation;
using Serilog;

namespace Framework.Timer
{
    internal class IntervalTimer : IIntervalTimer
    {
        private static Stopwatch _stopwatch;
        private Func<Task> _callback;
        private int _interval;

        public IntervalTimer()
        {
            _stopwatch = new Stopwatch();
        }

        public IIntervalTimer Run(int interval, Func<Task> callback)
        {
            _interval = interval;
            _callback = callback;
            _stopwatch.Start();
            return this;
        }

        public Task CheckAsync()
        {
            Validate.NotNull(_interval, nameof(_interval));
            Validate.NotNull(_callback, nameof(_callback));
            
            if (_stopwatch.Elapsed.Minutes >= _interval)
            {
                Log.Debug($"Execute interval {_interval} timer after {_stopwatch.Elapsed.Minutes} minutes");
                _callback();
                _stopwatch.Restart();
            }
            
            return Task.CompletedTask;
        }
    }
}