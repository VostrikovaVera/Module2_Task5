using Module2_Task5.Common.Enums;

namespace Module2_Task5.Services.Contracts
{
    public interface ILoggerService
    {
        public void LogEvent(LogTypes status, string message, string logsPath);
    }
}
