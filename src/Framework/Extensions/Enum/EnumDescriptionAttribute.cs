using System.ComponentModel;

namespace Framework.Extensions.Enum;

[AttributeUsage(AttributeTargets.All)]
[Serializable]
public class EnumDescriptionAttribute : DescriptionAttribute
{
    public EnumDescriptionAttribute(string description) : base(description)
    {
    }
}