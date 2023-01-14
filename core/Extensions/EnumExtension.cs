using System.ComponentModel;
using System.Reflection;

namespace core.Extensions;

/// <summary>
/// Enum Extension
/// </summary>
public static class EnumExtension
{
    /// <summary>
    /// GetDescription
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string GetDescription(this Enum value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString())!;

        DescriptionAttribute? attribute
                = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                    as DescriptionAttribute;

        return attribute?.Description ?? value.ToString();
    }
}