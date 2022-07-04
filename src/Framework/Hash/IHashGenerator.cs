namespace Framework.Hash;

public interface IHashGenerator
{
    string Sha256(string input);
    string HmacSha256(string key, string input);
}