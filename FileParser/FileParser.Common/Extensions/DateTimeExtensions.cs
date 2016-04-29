using System;
using System.Data.SqlTypes;
using System.Globalization;

namespace FileParser.Common.Extensions
{
	public static class DateTimeExtensions
	{
		public static string ToRelativeAgainstNow(this DateTime value)
		{
			double numericValue;
			string unit;
			bool plural;

			var timespan = DateTime.Now - value;
			var absoluteSeconds = Math.Abs(timespan.TotalSeconds);
			if (absoluteSeconds <= 15)
			{
				return "now";
			}

			if (absoluteSeconds < 60)
			{
				numericValue = absoluteSeconds;
				unit = "second";
				plural = true;
			}
			else if (absoluteSeconds < 3600)
			{
				numericValue = Math.Abs(timespan.TotalMinutes);
				unit = "minute";
				plural = absoluteSeconds >= 120;
			}
			else if (absoluteSeconds < 86400)
			{
				numericValue = Math.Abs(timespan.TotalHours);
				unit = "hour";
				plural = absoluteSeconds >= 7200;
			}
			else if (absoluteSeconds <= 604800)
			{
				numericValue = Math.Abs(timespan.TotalDays);
				unit = "day";
				plural = absoluteSeconds >= 172800;
			}
			else if (absoluteSeconds <= 2592000)
			{
				numericValue = Math.Abs(timespan.TotalDays / 7);
				unit = "week";
				plural = absoluteSeconds >= 1209600;
			}
			else if (absoluteSeconds <= 31536000)
			{
				numericValue = Math.Abs(timespan.TotalDays / 30);
				unit = "month";
				plural = absoluteSeconds >= 5184000;
			}
			else
			{
				numericValue = Math.Abs(timespan.TotalDays / 365);
				unit = "year";
				plural = absoluteSeconds >= 63072000;
			}

			if (plural)
			{
				unit += "s";
			}

			return timespan.TotalSeconds < 0
				? $"in {(int)numericValue} {unit}"
				: $"{(int)numericValue} {unit} ago";
		}

		public static string ToStringInvariant(this DateTime? value)
		{
			return value == null ? string.Empty : ToStringInvariant(value.Value);
		}

		public static string ToStringInvariant(this DateTime value)
		{
			return value.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
		}

		public static string ToDateStringInvariant(this DateTime? value)
		{
			return value == null ? string.Empty : ToDateStringInvariant(value.Value);
		}

		public static string ToDateStringInvariant(this DateTime value)
		{
			return value.ToString(DateFormat, CultureInfo.InvariantCulture);
		}

		public static string ToDateWithDayOfWeekFormatStringInvariant(this DateTime? value)
		{
			return value == null ? string.Empty : ToDateWithDayOfWeekFormatStringInvariant(value.Value);
		}

		public static string ToDateWithDayOfWeekFormatStringInvariant(this DateTime value)
		{
			return value.ToString(DateWithDayOfWeekFormat, CultureInfo.InvariantCulture);
		}

		public static string ToDateHourMinuteStringInvariant(this DateTime? value)
		{
			return value == null ? string.Empty : ToDateHourMinuteStringInvariant(value.Value);
		}

		public static string ToDateHourMinuteStringInvariant(this DateTime value)
		{
			return value.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
		}

		public static string ToTimeStringInvariant(this DateTime? value)
		{
			return value == null ? string.Empty : ToTimeStringInvariant(value.Value);
		}

		public static string ToTimeStringInvariant(this DateTime value)
		{
			return value.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
		}

		public static string ToUtcStringInvariant(this DateTime value)
		{
			return value.ToUniversalTime().ToString(UtcFormat, CultureInfo.InvariantCulture);
		}

		public static DateTime ToExactUtcDateTime(this string value)
		{
			return DateTime.ParseExact(value, UtcFormat, CultureInfo.InvariantCulture).ToUniversalTime();
		}

		public static DateTime ToExactDateTime(this string value)
		{
			return DateTime.ParseExact(value, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None);
		}

		public static DateTime ToExactDate(this string value)
		{
			return DateTime.ParseExact(value, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None);
		}

		public static bool IsExactDateTime(this string value)
		{
			DateTime result;
			if (!string.IsNullOrEmpty(value))
				return DateTime.TryParseExact(value, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
			return false;
		}

		public static bool IsExactDate(this string value)
		{
			DateTime result;
			if (!string.IsNullOrEmpty(value))
				return value.TryParseExactDateTime(out result);
			return false;
		}

		public static bool TryParseExactDateTime(this string value, out DateTime result)
		{
			return DateTime.TryParseExact(value, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
		}

		public static DateTime? NullableExactDateTime(this string value)
		{
			DateTime result;
			if (!string.IsNullOrEmpty(value) && DateTime.TryParseExact(value, DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
				return result;
			return null;
		}

		public static int ToUnixTime(this DateTime self)
		{
			return (int)(self.ToUniversalTime() - UnixEpoch).TotalSeconds;
		}

		public static DateTime FromUnixTime(this long self)
		{
			return UnixEpoch.AddSeconds(self).ToLocalTime();
		}

		public static bool EqualsIgnoreMilliseconds(this DateTime self, DateTime other)
		{
			return Math.Abs((self - other).TotalSeconds) < 1;
		}

		public static DateTime? EndOfDay(this DateTime? time)
		{
			return time?.EndOfDay();
		}

		public static DateTime EndOfDay(this DateTime time)
		{
			return time.Date.AddDays(1).AddMilliseconds(-1);
		}

		public static DateTime ToSmallDateTime(this DateTime self)
		{
			var smallDateTime = new DateTime(self.Year, self.Month, self.Day, self.Hour, self.Minute, 0);
			if (self.Second >= 30) smallDateTime = smallDateTime.AddMinutes(1);
			return smallDateTime;
		}

		public static int MonthsAgo(this DateTime self)
		{
			return self.MonthsDifference(DateTime.Now);
		}

		public static int MonthsDifference(this DateTime self, DateTime other)
		{
			return Math.Abs((self.Month - other.Month) + 12 * (self.Year - other.Year));
		}

		public static DateTime ToSqlDateTime(this DateTime date)
		{
			return new SqlDateTime(date).Value;
		}

		public static DateTime ToStartOfWeek(this DateTime self, DayOfWeek dayOfWeek = DayOfWeek.Sunday)
		{
			var diff = self.DayOfWeek - dayOfWeek;
			if (diff < 0) diff += 7;
			return self.AddDays(-1 * diff).Date;
		}

		
		public const string UtcFormat = "yyyy-MM-ddTHH:mm:ssZ";
		private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
		private const string DateFormat = "yyyy-MM-dd";
		private const string DateWithDayOfWeekFormat = "yyyy-MM-dd (dddd)";
		private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
	}
}
