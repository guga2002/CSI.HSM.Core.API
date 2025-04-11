using AutoMapper;
using Core.Application.DTOs.Request.LogModel;
using Core.Application.DTOs.Response.LogModel;
using Core.Application.Interface.LogInterfaces;
using Domain.Core.Entities.LogEntities;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.LogEntities;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Core.Application.Services.LogService.Services
{
    public class LogService : GenericService<LogDto, LogResponseDto, long, Logs>, ILogService
    {
        private readonly ILogsRepository _logsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<LogService> _logger;
        private static readonly HashSet<string> ValidLogLevels = new() { "TRACE", "DEBUG", "INFO", "WARN", "ERROR", "FATAL" };

        public LogService(
            IMapper mapper,
            ILogsRepository logsRepository,
            ILogger<LogService> logger,
            IGenericRepository<Logs> repository,
            IAdditionalFeaturesRepository<Logs> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _logsRepository = logsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        private void ValidatePositiveId(long id, string paramName)
        {
            if (id <= 0)
            {
                _logger.LogWarning("{ParameterName} must be a positive number.", paramName);
                throw new ArgumentException($"{paramName} must be greater than zero.", paramName);
            }
        }

        private void ValidateString(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _logger.LogWarning("{ParameterName} cannot be empty or whitespace.", paramName);
                throw new ArgumentException($"{paramName} cannot be empty or whitespace.", paramName);
            }
        }

        private void ValidateLogLevel(string logLevel)
        {
            if (!ValidLogLevels.Contains(logLevel.ToUpper()))
            {
                _logger.LogWarning("Invalid log level: {LogLevel}", logLevel);
                throw new ArgumentException($"Invalid log level: {logLevel}. Allowed values: TRACE, DEBUG, INFO, WARN, ERROR, FATAL.");
            }
        }

        private void ValidateRequestId(string requestId)
        {
            if (!Regex.IsMatch(requestId, @"^[a-zA-Z0-9\-]+$"))
            {
                _logger.LogWarning("Invalid request ID format: {RequestId}", requestId);
                throw new ArgumentException("Invalid request ID format.");
            }
        }

        private void ValidateDays(int days)
        {
            if (days <= 0)
            {
                _logger.LogWarning("Days parameter must be greater than zero.");
                throw new ArgumentException("Days must be greater than zero.");
            }
        }

        public async Task<IEnumerable<LogResponseDto>> GetLogsBySeverity(string logLevel, CancellationToken cancellationToken = default)
        {
            ValidateLogLevel(logLevel);

            var logs = await _logsRepository.GetLogsBySeverity(logLevel);
            return _mapper.Map<IEnumerable<LogResponseDto>>(logs);
        }

        public async Task<IEnumerable<LogResponseDto>> GetLogsByUser(long loggerId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(loggerId, nameof(loggerId));

            var logs = await _logsRepository.GetLogsByUser(loggerId);
            return _mapper.Map<IEnumerable<LogResponseDto>>(logs);
        }

        public async Task<IEnumerable<LogResponseDto>> GetLogsByRequestId(string requestId, CancellationToken cancellationToken = default)
        {
            ValidateString(requestId, nameof(requestId));
            ValidateRequestId(requestId);

            var logs = await _logsRepository.GetLogsByRequestId(requestId);
            return _mapper.Map<IEnumerable<LogResponseDto>>(logs);
        }

        public async Task<bool> DeleteOldLogs(int days, CancellationToken cancellationToken = default)
        {
            ValidateDays(days);

            return await _logsRepository.DeleteOldLogs(days);
        }
    }
}
