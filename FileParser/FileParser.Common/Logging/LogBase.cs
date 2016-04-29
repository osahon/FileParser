using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileParser.Common.Extensions;

namespace FileParser.Common.Logging
{
	public abstract class LogBase : ILog
	{
		public virtual void InfoFormat(string format, params object[] args)
		{
			Log(LogLevel.Info, format, args);
		}

		public virtual void WarnFormat(string format, params object[] args)
		{
			Log(LogLevel.Warn, format, args);
		}

		public virtual void Error(string error, Exception exception)
		{
			Log(LogLevel.Error, "Error: " + error + ". Exception:" + exception);
		}

		public virtual void Fatal(string fatal, Exception exception)
		{
			Log(LogLevel.Error, "Fatal: " + fatal + ". Exception:" + exception);
		}

		public virtual void Info(string info)
		{
			Log(LogLevel.Info, info);
		}

		public virtual bool IsEnabled(LogLevel level)
		{
			return true;
		}

		public abstract void Log(LogLevel level, string format, params object[] args);

		public virtual void LogEvent(string message, object values)
		{
			var valuesAsDictionary = values.GetPropertiesAsKeyValuePairs();
			var formattedMessage = message.FormatByKeys(valuesAsDictionary);
			var formattedValues = ConvertDictionaryToSingleLine(valuesAsDictionary);
			Info(formattedMessage + ":" + formattedValues);
		}

		public virtual void LogMetric(string metricName, long value)
		{
			Log(LogLevel.Trace, $"{metricName}: {value}");
		}

		public virtual void IncrementCounter(string category, string name)
		{
		}

		public virtual void SetUserContext(string user, string account)
		{
		}

		private static string ConvertDictionaryToSingleLine(IEnumerable<KeyValuePair<string, object>> keyValues)
		{
			var sb = new StringBuilder(100);
			foreach (var pair in keyValues)
			{
				sb.Append($"{pair.Key} = {pair.Value}, ");
			}
			if (sb.Length > 0)
			{
				return sb.ToString().Substring(0, sb.Length - 2);
			}
			return string.Empty;
		}

		public void Dispose()
		{
		}
	}
}
