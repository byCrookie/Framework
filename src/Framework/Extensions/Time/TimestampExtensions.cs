namespace Framework.Extensions.Time;

public static class TimestampExtensions
{
    public static DateTime ConvertTimestamp(long miliseconds)
    {
        return new DateTime(1970, 1, 1) + TimeSpan.FromMilliseconds(miliseconds);
    }

    public static long TimestampNow()
    {
        var now = (DateTimeOffset)DateTime.UtcNow;
        return now.ToUnixTimeMilliseconds();
    }
}