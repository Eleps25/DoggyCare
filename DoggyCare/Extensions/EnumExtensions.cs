using System.ComponentModel;
using System.Reflection;

namespace DoggyCare.Extensions {
    public static class EnumExtensions {
        public static string GetEnumDescription(this Enum value) {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attr = field.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description ?? value.ToString();
        }
    }
}
