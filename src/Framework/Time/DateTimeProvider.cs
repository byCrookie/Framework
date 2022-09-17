namespace Framework.Time;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now()
    {
        return DateTime.Now;
    }
    
    public DateTime UtcNow()
    {
        return DateTime.UtcNow;
    }
}