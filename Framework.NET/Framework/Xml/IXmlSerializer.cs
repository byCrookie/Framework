namespace Framework.Xml
{
    public interface IXmlSerializer
    {
        string Serialize<T>(T objectToParse) where T : class, new();
        T Deserialize<T>(string xmlTextToParse) where T : class, new();
    }
}