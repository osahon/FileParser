using System;
using System.IO;
using System.Configuration;
using FileParser.Common.Extensions;

namespace FileParser.Common.Logging
{
	public interface IFileLogger
	{
		void LogMessage(string message);
	}

	public class FileLogger : IFileLogger
	{
		public FileLogger(string subFolder, string formatForName)
		{
			this.subFolder = subFolder;
			this.formatForName = formatForName;
		}

		public void LogMessage(string message)
		{
			var file = string.Format(formatForName, DateTime.Now.ToDateStringInvariant());
			var path = GetFullPath(file);

			try
			{
				CreateSubfolderIfMissing(path);
				File.AppendAllText(path, message);
			}
			catch (IOException) { }
		}

		private void CreateSubfolderIfMissing(string filePath)
		{
			var fi = new FileInfo(filePath);
			if (!fi.Directory.Exists) { fi.Directory.Create(); }
		}

		private string GetFullPath(string filename)
		{
			var path = Path.Combine(SaveFolder, subFolder);
			return Path.Combine(path, filename);
		}

		private readonly string SaveFolder = ConfigurationManager.AppSettings["LogFilePath"];
		private readonly string subFolder;
		private readonly string formatForName;
	}
}
