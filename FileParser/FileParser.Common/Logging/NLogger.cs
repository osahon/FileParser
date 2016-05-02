using System;
using System.IO;
using System.Linq;
using NLog;
using NLog.Targets;
using LogLevel = FileParser.Common.Logging.LogLevel;

namespace FileParser.Common.Logging
{
	public class NLogger : LogBase
	{
		private readonly Lazy<Logger> lazyLogger;
		private Logger Logger => lazyLogger.Value;

		public NLogger(string loggerName)
		{
			lazyLogger = new Lazy<Logger>(() => LogManager.GetLogger(loggerName));
		}

		public override void Error(string error, Exception exception)
		{
			Logger.ErrorException(error, exception);
		}

		public override void Fatal(string fatal, Exception exception)
		{
			Logger.FatalException(fatal, exception);
		}

		public override bool IsEnabled(LogLevel level)
		{
			try
			{
				return Logger.IsEnabled(NLog.LogLevel.FromOrdinal((int)level));
			}
			catch (ArgumentException)
			{
				return false;
			}
		}

		public override void Log(LogLevel level, string format, params object[] args)
		{
			try
			{
				Logger.Log(NLog.LogLevel.FromOrdinal((int)level), format, args);
			}
			catch (ArgumentException)
			{
				Logger.Error("Invalid LogLevel '{0}:{1}' message '{2}'", level, (int)level, string.Format(format, args));
			}
		}

		public static bool TryGetLogfileContent(string loggerName, out string result)
		{
			LogManager.Flush();
			var fileTarget = LogManager.Configuration.ConfiguredNamedTargets.FirstOrDefault(t =>
				t.GetType().IsAssignableFrom(typeof(FileTarget)) && t.Name == loggerName) as FileTarget;
			if (fileTarget == null)
			{
				result = $"Logger '{loggerName}' not found.";
				return false;
			}

			var fileName = fileTarget.FileName.Render(LogEventInfo.CreateNullEvent());
			if (!File.Exists(fileName))
			{
				result = $"File '{fileName}' not found.";
				return false;
			}

			result = File.ReadAllText(fileName);
			return true;
		}
	}
}
