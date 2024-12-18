using GuestSide.Core.Interfaces.LogInterfaces;
using Microsoft.Extensions.Logging;

namespace Core.Persistance.LoggingConfigs
{
    public class Logger : ILogger
    {
        private readonly ILogRepository _log;

        public Logger(ILogRepository log)
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
            var res=_log.AddAsync(new GuestSide.Core.Entities.LogEntities.Logs
            {
                LogLevel = logLevel.ToString(),
                Message = formatter(state, exception),
                Exception = exception?.Message,
                CorrelationId = Guid.NewGuid(),
                Source = exception.StackTrace,
                Timestamp = DateTime.Now,
                IsEmergency = logLevel == LogLevel.Critical || logLevel == LogLevel.Error
            }).Result;
        }
    }
}
