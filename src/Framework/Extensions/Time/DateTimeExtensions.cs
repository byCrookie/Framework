namespace Framework.Extensions.Time;

internal static class DateTimeExtensions
{
    public static DateTime? SetKindUtc(this DateTime? dateTime)
    {
        return dateTime?.SetKindUtc();
    }
    public static DateTime SetKindUtc(this DateTime dateTime)
    {
        return dateTime.Kind == DateTimeKind.Utc 
            ? dateTime 
            : DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
    }
}