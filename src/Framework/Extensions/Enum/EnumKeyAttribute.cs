﻿using System.ComponentModel;

namespace Framework.Extensions.Enum;

[AttributeUsage(AttributeTargets.All)]
[Serializable]
public class EnumKeyAttribute : DescriptionAttribute
{
    public EnumKeyAttribute(string key) : base(key)
    {
    }
}