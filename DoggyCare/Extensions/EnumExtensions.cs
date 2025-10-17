using System.ComponentModel;
using System.Reflection;

namespace DoggyCare.Extensions {
    internal class EnumExtensions {
        public static string GetEnumDescription(Enum value) {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attr = field.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description ?? value.ToString();
        }
    }
}
