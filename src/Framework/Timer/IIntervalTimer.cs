namespace Framework.Timer;

public interface IIntervalTimer
{
    IIntervalTimer Run(TimeSpan interval, Func<Task> callback);
    Task CheckAsync();
}