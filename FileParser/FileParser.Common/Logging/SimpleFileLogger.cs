using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Common.Logging
{
	public class SimpleFileLogger : LogBase
	{
		private string Date => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff");
		private readonly string loggerName;
		private readonly FileLogger fileLogger;

		public SimpleFileLogger(string loggerName, string formatForFileName)
		{
			this.loggerName = loggerName;
			fileLogger = new FileLogger("Logs", formatForFileName);
		}

		public override void InfoFormat(string format, params object[] args)
		{
			fileLogger.LogMessage(CreateMessage("INFO", string.Format(format, args)));
		}

		public override void WarnFormat(string format, params object[] args)
		{
			fileLogger.LogMessage(CreateMessage("WARNING", string.Format(format, args)));
		}

		public override void Error(string error, Exception exception)
		{
			Error(string.Format(error + " - {0}", exception));
		}

		private void Error(string message)
		{
			fileLogger.LogMessage(CreateMessage("ERROR", message));
		}

		public override void Fatal(string fatal, Exception exception)
		{
			Fatal(string.Format(fatal + " - {0}", exception));
		}

		private void Fatal(string message)
		{
			fileLogger.LogMessage(CreateMessage("FATAL", message));
		}

		public override void Info(string info)
		{
			fileLogger.LogMessage(CreateMessage("INFO", info));
		}

		public override void Log(LogLevel level, string format, params object[] args)
		{
			var message = string.Format(format, args);
			switch (level)
			{
				case LogLevel.Warn:
					WarnFormat(message);
					break;
				case LogLevel.Error:
					Error(message);
					break;
				case LogLevel.Fatal:
					Fatal(message);
					break;
				default:
					InfoFormat(message);
					break;
			}
		}

		private string CreateMessage(string tag, string extra)
		{
			var message = new StringBuilder();
			message.AppendFormat("{0} - {1} - {2}", Date, tag, loggerName);
			message.AppendLine(extra);
			return message.ToString();
		}
	}
}
