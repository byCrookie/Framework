namespace Framework.Hash
{
    public interface IHashGenerator
    {
        public string HmacSha256(string key, string message);
    }
}