using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FileParser.Common.Extensions
{
	public static class StringExtensions
	{
		public static bool IsDigitsOnly(this string str)
		{
			return str.All(c => c >= '0' && c <= '9');
		}

		public static bool IsInteger(this string str)
		{
			int val;
			return int.TryParse(str, out val);
		}

		public static bool HasAValue(this string value)
		{
			return !string.IsNullOrEmpty(value) && value != "NaN";
		}

		public static T ConvertTo<T>(this object obj, T @default = default(T))
		{
			try
			{
				if (obj != null)
				{
					var conv = TypeDescriptor.GetConverter(typeof(T));
					var convertFrom = conv.ConvertFrom(obj);
					if (convertFrom != null) return (T)convertFrom;
				}
			}
			catch { }
			return @default;
		}

		public static T ConvertTo<T>(this string s, T @default = default(T))
		{
			return string.IsNullOrEmpty(s)
				? @default
				: ((object)s).ConvertTo(@default);
		}

		public static string[] ToStringArray(this string value)
		{
			return string.IsNullOrEmpty(value) ? new string[] { } : new[] { value };
		}

		public static string Shorten(this string value, int length)
		{
			return value.Length <= length ? value : value.Substring(0, length);
		}

		public static Uri ToUri(this string value)
		{
			return string.IsNullOrEmpty(value) ? null : new Uri(value);
		}

		public static string ToLowerCaseString(this object value)
		{
			return value?.ToString().ToLower() ?? string.Empty;
		}

		public static bool IsNullOrWhitespace(this string self)
		{
			return string.IsNullOrWhiteSpace(self);
		}

		public static string ToNullIfWhitespace(this string self)
		{
			return self.IsNullOrWhitespace() ? null : self;
		}

		public static string FormatByKeys(this string message, IDictionary<string, object> value)
		{
			if (value == null)
				return message;
			var sb = new StringBuilder(message);
			foreach (var entry in value)
				sb.Replace("{" + entry.Key + "}", entry.Value?.ToString() ?? "");

			return sb.ToString();
		}
	}
}
