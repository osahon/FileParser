using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Common.Logging
{
	public interface ILogProvider
	{
		ILog GetLogger(string loggerName);
	}

	public class SimpleFileLogProvider : ILogProvider
	{
		private readonly string formatForFileName;

		public SimpleFileLogProvider(string formatForFileName)
		{
			this.formatForFileName = formatForFileName;
		}

		public ILog GetLogger(string loggerName)
		{
			return new SimpleFileLogger(loggerName, formatForFileName);
		}
	}

	public class NLoggerLogProvider : ILogProvider
	{
		public ILog GetLogger(string loggerName)
		{
			return new NLogger(loggerName ?? "noLoggerNameProvided");
		}
	}
}
