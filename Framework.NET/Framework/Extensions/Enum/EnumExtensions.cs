using System;
using System.ComponentModel;
using System.Linq;
using Framework.Validation;

namespace Framework.Extensions.Enum
{
    public static class EnumExtensions
    {
        public static string GetDescription<TEnum>(this TEnum source)
        {
            Validate.NotNull(source, nameof(source));
            var fi = source.GetType().GetField(source.ToString()!);
            var attributes = (DescriptionAttribute[])fi?.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes is {Length: > 0} ? attributes[0].Description : source.ToString();
        }

        public static string GetKey<TEnum>(this TEnum source)
        {
            Validate.NotNull(source, nameof(source));
            var fi = source.GetType().GetField(source.ToString()!);
            var attributes = (EnumKeyAttribute[])fi?.GetCustomAttributes(typeof(EnumKeyAttribute), false);
            return attributes is {Length: > 0} ? attributes[0].Description : source.ToString();
        }

        public static T ToEnumByKey<T>(this string value)
        {
            foreach (var enumValue in typeof(T).GetEnumValues())
            {
                var field = typeof(T).GetField(enumValue.ToString()!);
                var keyAttributes = (EnumKeyAttribute[])field?.GetCustomAttributes(typeof(EnumKeyAttribute), false);
                if (keyAttributes?.Any(a => a.Description == value) ?? false)
                {
                    return (T) enumValue;
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
                    return (T) enumValue;
                }
            }

            throw new ArgumentException($"Can not convert value {value} to enum {typeof(T)} by description");
        }

        public static T ToEnumByValue<T>(this string value)
        {
            return (T) System.Enum.Parse(typeof(T), value, true);
        }
    }
}