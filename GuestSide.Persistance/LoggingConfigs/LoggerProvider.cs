using Core.Core.Interfaces.LogEntities;
using Microsoft.Extensions.Logging;

namespace Core.Persistance.LoggingConfigs
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly ILogsRepository log;

        public LoggerProvider(ILogsRepository log)
        {
            this.log = log;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(log);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
