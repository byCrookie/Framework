namespace Framework.Extensions.Enum;

[AttributeUsage(AttributeTargets.All)]
[Serializable]
public class EnumDataAttribute : Attribute
{
    public object? Data { get; }

    public EnumDataAttribute(object? data)
    {
        Data = data;
    }
}