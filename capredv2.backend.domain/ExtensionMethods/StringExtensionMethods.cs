using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace capredv2.backend.domain.ExtensionMethods
{
	public static class StringExtensionMethods
	{
		public static DateTime? TryParseDateTime(this string dateString, string format = null)
		{
			var success = format == null
				? DateTime.TryParse(dateString, out var dt)
				: DateTime.TryParseExact(dateString, format, null, DateTimeStyles.None, out dt);

			return success ? dt : (DateTime?)null;
		}

		public static long? TryParseLong(this string dateString)
		{
			var success = long.TryParse(dateString, out var outPutLong);

			return success ? outPutLong : (long?)null;
		}

		public static double? TryParseDouble(this string doubleString)
		{
			var success = double.TryParse(doubleString, out var outPutLong);

			return success ? outPutLong : (double?)null;
		}

		public static string NullIfEmpty(this string content)
		{
			if (content == "\"\"")
				return null;

			return string.IsNullOrWhiteSpace(content) ? null : content;
		}
        public static string GetStringFromObject(object obj)
        {
            Type myType = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            string retValue = "";
            foreach (PropertyInfo prop in props)
            {
                retValue += prop.GetValue(obj, null) + ", ";
            }
            return retValue;
        }
    }
}
