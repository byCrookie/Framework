using System.Text;

namespace Framework.Unique;

public class UniqueGenerator : IUniqueGenerator
{
    private static readonly char[] Chars =
        "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

    private static readonly Random Random = new();

    public Guid NewGuid()
    {
        return Guid.NewGuid();
    }

    public string NewShortGuid()
    {
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('=').Replace("/", "")
            .Replace("+", "");
    }

    public string GetBase62(int length = 10)
    {
        var sb = new StringBuilder(length);

        for (var i = 0; i < length; i++)
        {
            sb.Append(Chars[Random.Next(62)]);
        }

        return sb.ToString();
    }
}