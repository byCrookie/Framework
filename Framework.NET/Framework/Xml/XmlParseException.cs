using System;

namespace Framework.Xml
{
	public class XmlParseException : Exception
	{
		public XmlParseException(string message, Exception argumentException) : base(message, argumentException) { }
	}
}