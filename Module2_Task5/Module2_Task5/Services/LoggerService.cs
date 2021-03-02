using System;
using Module2_Task5.Common.Enums;
using Module2_Task5.Services.Contracts;

namespace Module2_Task5.Services
{
    public class LoggerService : ILoggerService
    {
        private static readonly ILoggerService _instance = new LoggerService();
        private static readonly IFileService _fileService = new FileService();

        static LoggerService()
        {
        }

        private LoggerService()
        {
        }

        public static ILoggerService Instance => _instance;

        public void LogEvent(LogTypes status, string message, string logsPath)
        {
            var logItem = $"{DateTime.UtcNow}: {status}: {message}";
            Console.WriteLine(logItem);

            _fileService.Write(logsPath, logItem);
        }
    }
}
