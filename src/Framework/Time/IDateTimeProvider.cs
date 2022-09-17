namespace Framework.Time;

public interface IDateTimeProvider
{
    public DateTime Now();
    public DateTime UtcNow();
}