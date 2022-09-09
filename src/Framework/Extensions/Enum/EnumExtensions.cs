using System.ComponentModel;

namespace Framework.Extensions.Enum;

public static class EnumExtensions
{
    public static object? GetData<TEnum, TData>(this TEnum source)
        where TEnum : notnull
        where TData : class
    {
        var field = source.GetType().GetField(source.ToString()!);
        var customAttributes = field?.GetCustomAttributes(typeof(EnumDataAttribute), false);
        if (customAttributes is null) throw new ArgumentException($"Enum {typeof(TEnum).Name} has no attribute of type {nameof(EnumDataAttribute)}");
        var attributes = (EnumDataAttribute[])customAttributes;

        if (attributes.Length <= 0)
        {
            throw new Exception($"Enum {typeof(TEnum).Name} has no attribute of type {nameof(EnumDataAttribute)}");
        }

        return attributes[0].Data switch
        {
            null => null,
            TData data => data,
            _ => throw new ArgumentException($"Data is not of type {typeof(TData).Name}")
        };
    }

    public static string GetDescription<TEnum>(this TEnum source) where TEnum : notnull
    {
        return GetInternalDescriptionOfAttribute<EnumDescriptionAttribute, TEnum>(source);
    }

    public static string GetKey<TEnum>(this TEnum source) where TEnum : notnull
    {
        return GetInternalDescriptionOfAttribute<EnumKeyAttribute, TEnum>(source);
    }

    public static string GetName<TEnum>(this TEnum source) where TEnum : notnull
    {
        return GetInternalDescriptionOfAttribute<EnumNameAttribute, TEnum>(source);
    }

    private static string GetInternalDescriptionOfAttribute<TAttribute, TEnum>(this TEnum source)
        where TEnum : notnull
        where TAttribute : DescriptionAttribute
    {
        var field = source.GetType().GetField(source.ToString()!);
        var customAttributes = field?.GetCustomAttributes(typeof(TAttribute), false);
        if (customAttributes is null) throw new ArgumentException($"Enum {typeof(TEnum).Name} has no attribute of type {typeof(TAttribute).Name}");
        var attributes = (TAttribute[])customAttributes;

        if (attributes.Length <= 0)
        {
            throw new Exception($"Enum {typeof(TEnum).Name} has no attribute of type {nameof(EnumDataAttribute)}");
        }

        return attributes[0].Description;
    }

    public static T ToEnumByKey<T>(this string value)
    {
        return ToEnumByInternalAttribute<EnumKeyAttribute, T>(value);
    }

    public static T ToEnumByName<T>(this string value)
    {
        return ToEnumByInternalAttribute<EnumNameAttribute, T>(value);
    }


    public static T ToEnumByDescription<T>(this string value) where T : System.Enum
    {
        return ToEnumByInternalAttribute<EnumDescriptionAttribute, T>(value);
    }

    private static T ToEnumByInternalAttribute<TAttribute, T>(this string value)
        where TAttribute : DescriptionAttribute
    {
        foreach (var enumValue in typeof(T).GetEnumValues())
        {
            var field = typeof(T).GetField(enumValue.ToString()!);
            var customAttributes = field?.GetCustomAttributes(typeof(TAttribute), false);
            if (customAttributes is null) throw new ArgumentException($"Enum {typeof(T).Name} has no attributes of type {typeof(TAttribute).Name}");
            var keyAttributes = (TAttribute[])customAttributes;
            if (keyAttributes.Any(a => a.Description == value))
            {
                return (T)enumValue;
            }
        }

        throw new ArgumentException($"Can not convert value {value} to enum {typeof(T).Name} by attribute {typeof(TAttribute).Name}");
    }

    public static T ToEnumByValue<T>(this string value)
    {
        return (T)System.Enum.Parse(typeof(T), value, true);
    }
}