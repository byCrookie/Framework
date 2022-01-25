namespace Framework.Unique;

public interface IUniqueGenerator
{
    System.Guid NewGuid();
    string NewShortGuid();
    string GetBase62(int length = 10);
}