﻿using System.Globalization;

namespace Framework.Xml;

public class XmlSerializer : IXmlSerializer
{
	public string Serialize<T>(T objectToParse) where T : class, new()
	{
		if (objectToParse == null)
		{
			throw new XmlParseException("Unable to parse a object which is null.", new ArgumentNullException(nameof(objectToParse)));
		}

		var stringWriter = new StringWriter(new CultureInfo("de-CH"));
		var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
			
		try
		{
			serializer.Serialize(stringWriter, objectToParse);
		}
		catch (Exception e)
		{
			throw new XmlParseException($"Unable to serialize the object {objectToParse.GetType()}.", e);
		}

		return stringWriter.ToString();
	}

	public T? Deserialize<T>(string xmlTextToParse) where T : class, new()
	{
		if (string.IsNullOrEmpty(xmlTextToParse))
		{
			throw new XmlParseException("Invalid string input. Cannot parse an empty or null string.", new ArgumentException("xmlTestToParse"));

		}

		var stringReader = new StringReader(xmlTextToParse);
		var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
			
		try
		{
			return serializer.Deserialize(stringReader) as T;
		}
		catch (Exception e)
		{
			throw new XmlParseException($"Unable to convert to given string into the type {typeof(T)}. See inner exception for details.", e);
		}
	}
}