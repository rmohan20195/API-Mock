using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace capredv2.backend.domain.ExtensionMethods
{
    public static class EnumExtensionMethods
    {
        public static string GetEnumMemberValue<T>(this T value) where T : struct, IConvertible
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString(CultureInfo.InvariantCulture))
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }
    }
}
