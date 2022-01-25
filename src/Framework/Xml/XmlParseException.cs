namespace Framework.Xml;

internal class XmlParseException : Exception
{
	public XmlParseException(string message, Exception argumentException) : base(message, argumentException) { }
}