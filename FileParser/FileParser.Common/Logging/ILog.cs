using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Common.Logging
{
	public enum LogLevel
	{
		Trace = 0,
		Debug = 1,
		Info = 2,
		Warn = 3,
		Error = 4,
		Fatal = 5
	}

	public interface ILog : IDisposable
	{
		void InfoFormat(string format, params object[] args);
		void WarnFormat(string format, params object[] args);
		void Error(string error, Exception exception);
		void Fatal(string fatal, Exception exception);
		void Info(string info);
		bool IsEnabled(LogLevel level);
		void Log(LogLevel level, string format, params object[] args);

		/// <summary>
		/// Logs a custom event containing structured data.
		/// </summary>
		/// <param name="message">A free text string describing the event. The message may contain format strings within curly brackets corresponding to the names from the values object. E.g. "Hello {Name}"</param>
		/// <param name="values">A object (i.e. a dynamic) containing the structured data as key-value pairs. E.g. new {UserName = currentUser.Name, Action = myCurrentAction} </param>
		void LogEvent(string message, object values = null);

		/// <summary>
		/// Logs a timed metric.
		/// </summary>
		/// <param name="metricName">A logical name of the metric beeing meassured</param>
		/// <param name="value">The value of the metric</param>
		void LogMetric(string metricName, long value);

		/// <summary>
		/// When supported, increment the a metric counter for the given name.
		/// </summary>
		/// <param name="category">A category that the counter belongs to</param>
		/// <param name="name">A logical name of the counter</param>
		void IncrementCounter(string category, string name);

		/// <summary>
		/// When supported, adds user information to the current context.
		/// </summary>
		/// <param name="user">An identifier of the current user</param>
		/// <param name="account">The company/account of the current user.</param>
		void SetUserContext(string user, string account);
	}
}
