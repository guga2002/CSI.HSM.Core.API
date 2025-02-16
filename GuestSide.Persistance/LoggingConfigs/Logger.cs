using Core.Core.Entities.LogEntities;
using Core.Core.Interfaces.LogEntities;
using Microsoft.Extensions.Logging;

namespace Core.Persistance.LoggingConfigs
{
    public class Logger : ILogger
    {
        private readonly ILogsRepository _log;

        public Logger(ILogsRepository log)
        {
            _log = log;
        }
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null; 
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
      
            if (logLevel is not LogLevel.Warning&&logLevel is not LogLevel.Information)
            {
                Console.WriteLine(exception?.Message);
                var res = _log.AddAsync(new Logs
                {
                    LogLevel = logLevel.ToString(),
                    Message = formatter(state, exception),
                    Exception = exception?.Message,
                    CorrelationId = Guid.NewGuid(),
                    Source = exception?.StackTrace,
                    Timestamp = DateTime.Now,
                    IsEmergency = logLevel == LogLevel.Critical || logLevel == LogLevel.Error
                }).Result;
            }
        }
    }
}
