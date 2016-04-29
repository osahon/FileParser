using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FileParser.Common.Extensions
{
	public static class ObjectExtensions
	{
		public static Dictionary<string, object> GetPropertiesAsKeyValuePairs(this object value)
		{
			if (value == null)
				return new Dictionary<string, object>(0);

			var dictionary = value as IDictionary;
			if (dictionary != null)
				return dictionary.Keys.Cast<object>().ToDictionary(key => key.ToString(), key => dictionary[key]);

			return value.GetType()
				.GetProperties(BindingFlags.Public | BindingFlags.Instance)
				.Select(x => new { Key = x.Name, Value = x.GetValue(value, null) })
				.ToDictionary(x => x.Key, x => x.Value);
		}
	}
}
