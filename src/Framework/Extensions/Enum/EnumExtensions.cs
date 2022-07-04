using System.ComponentModel;

namespace Framework.Extensions.Enum;

public static class EnumExtensions
{
    public static string GetDescription<TEnum>(this TEnum source) where TEnum : notnull
    {
        var field = source.GetType().GetField(source.ToString()!);
        var customAttributes = field?.GetCustomAttributes(typeof(DescriptionAttribute), false);
        if (customAttributes is null) throw new ArgumentException($"Enum {typeof(TEnum).Name} has no attributes");
        var attributes = (DescriptionAttribute[])customAttributes;
        if (attributes.Length > 0)
        {
            return attributes[0].Description;
        }
        
        return source.ToString() ?? string.Empty;
    }

    public static string GetKey<TEnum>(this TEnum source) where TEnum : notnull
    {
        var field = source.GetType().GetField(source.ToString()!);
        var customAttributes = field?.GetCustomAttributes(typeof(EnumKeyAttribute), false);
        if (customAttributes is null) throw new ArgumentException($"Enum {typeof(TEnum).Name} has no attributes");
        var attributes = (EnumKeyAttribute[])customAttributes;

        if (attributes.Length > 0)
        {
            return attributes[0].Description;
        }
        
        return source.ToString() ?? string.Empty;
    }

    public static T ToEnumByKey<T>(this string value)
    {
        foreach (var enumValue in typeof(T).GetEnumValues())
        {
            var field = typeof(T).GetField(enumValue.ToString()!);
            var customAttributes = field?.GetCustomAttributes(typeof(EnumKeyAttribute), false);
            if (customAttributes is null) throw new ArgumentException($"Enum {typeof(T).Name} has no attributes");
            var keyAttributes = (EnumKeyAttribute[])customAttributes;
            if (keyAttributes.Any(a => a.Description == value))
            {
                return (T)enumValue;
            }
        }

        throw new ArgumentException($"Can not convert value {value} to enum {typeof(T)} by key");
    }

    public static T ToEnumByDescription<T>(this string value) where T : System.Enum
    {
        foreach (var enumValue in typeof(T).GetEnumValues())
        {
            if (enumValue.GetDescription() == value)
            {
                return (T)enumValue;
            }
        }

        throw new ArgumentException($"Can not convert value {value} to enum {typeof(T)} by description");
    }

    public static T ToEnumByValue<T>(this string value)
    {
        return (T)System.Enum.Parse(typeof(T), value, true);
    }
}