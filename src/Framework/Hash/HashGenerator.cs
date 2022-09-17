using System.Security.Cryptography;
using System.Text;

namespace Framework.Hash;

public class HashGenerator : IHashGenerator
{
    public string Sha256(string input)
    {
        const string hexadecimal = "x2";
        
        using (var sha256Hash = SHA256.Create())
        {
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();
            foreach (var t in bytes)
            {
                builder.Append(t.ToString(hexadecimal));
            }

            return builder.ToString();
        }
    }

    public string HmacSha256(string key, string input)
    {
        var encoding = new ASCIIEncoding();

        var textBytes = encoding.GetBytes(input);
        var keyBytes = encoding.GetBytes(key);

        byte[] hashBytes;

        using (var hash = new HMACSHA256(keyBytes))
        {
            hashBytes = hash.ComputeHash(textBytes);
        }

        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }
}