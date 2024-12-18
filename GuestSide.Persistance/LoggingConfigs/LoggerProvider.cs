﻿using GuestSide.Core.Interfaces.LogInterfaces;
using Microsoft.Extensions.Logging;

namespace Core.Persistance.LoggingConfigs
{
    public class LoggerProvider : ILoggerProvider,IDisposable
    {
        private readonly ILogRepository log;

        public LoggerProvider(ILogRepository log)
        {
            this.log = log;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(log);
        }

        public void Dispose()
        {
            log.Dispose();
        }
    }
}
