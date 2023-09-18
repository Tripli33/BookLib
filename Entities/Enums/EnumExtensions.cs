namespace Entities.Enums;

public class EnumExtensions
{
    public static bool IsEnumNameValid<T>(string enumName)
    {
        foreach (T name in Enum.GetValues(typeof(T)))
        {
            if (string.Equals(enumName, name.ToString(), StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    public static T EnumNameToEnum<T>(string enumName, T defaultValue)
    {
        if (string.IsNullOrEmpty(enumName))
            return defaultValue;
        return (T)Enum.Parse(typeof(T), enumName, true);
    }
}