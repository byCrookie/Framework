using System.ComponentModel;

namespace Framework.Extensions.Enum;

[AttributeUsage(AttributeTargets.All)]
[Serializable]
public class EnumNameAttribute : DescriptionAttribute
{
    public EnumNameAttribute(string name) : base(name)
    {
    }
}