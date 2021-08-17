using System;
using System.Threading.Tasks;

namespace Framework.Timer
{
    public interface IIntervalTimer
    {
        IIntervalTimer Run(int interval, Func<Task> callback);
        Task CheckAsync();
    }
}