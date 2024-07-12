using System.ComponentModel;

namespace Employee.Permissions.Application.Utils.Enums
{

    public enum PermissionAction
    {
        [Description("Get")]
        Get_Action = 0,

        [Description("Request")]
        Request_Action = 1,

        [Description("Modify")]
        Modify_Action = 2,
    }
}

public static class EnumExtensions
{
    public static string GetEnumDescription(this Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
        return attributes?.Length > 0 ? attributes[0].Description : value.ToString();
    }
}