using System.Security.Cryptography;
using System.Text;

namespace Framework.Hash;

internal class HashGenerator : IHashGenerator
{
    public string HmacSha256(string key, string message)
    {
        return HashEncode(HashHmac(StringEncode(key), StringEncode(message)));
    }

    private static byte[] HashHmac(byte[] key, byte[] message)
    {
        var hash = new HMACSHA256(key);
        return hash.ComputeHash(message);
    }

    private static byte[] StringEncode(string text)
    {
        var encoding = new ASCIIEncoding();
        return encoding.GetBytes(text);
    }

    private static string HashEncode(byte[] hash)
    {
        return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }
}