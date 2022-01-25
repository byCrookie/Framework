namespace Framework.Extensions.String;

public static class StringExtensions
{
    public static string ToSystemString(this IEnumerable<char> source)
    {
        return new(source.ToArray());
    }
}