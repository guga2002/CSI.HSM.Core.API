using AutoMapper;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.Notification;
using Core.Core.Entities.Enums;
using Core.Core.Entities.Notification;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Notification;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Notification.Service
{
    public class NotificationService : GenericService<NotificationDto, NotificationResponseDto, long, Notifications>, INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(
            IMapper mapper,
            INotificationRepository notificationRepository,
            ILogger<NotificationService> logger,
            IGenericRepository<Notifications> repository,
            IAdditionalFeaturesRepository<Notifications> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _notificationRepository = notificationRepository;
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

        private void ValidateDateRange(DateTime start, DateTime end)
        {
            if (start > end)
            {
                _logger.LogWarning("Start date cannot be later than end date.");
                throw new ArgumentException("Start date cannot be later than end date.");
            }
        }

        private void ValidateCount(int count, string paramName)
        {
            if (count <= 0)
            {
                _logger.LogWarning("{ParameterName} must be greater than zero.", paramName);
                throw new ArgumentException($"{paramName} must be greater than zero.", paramName);
            }
        }

        public async Task<IEnumerable<NotificationResponseDto>> GetUnsentNotifications(CancellationToken cancellationToken = default)
        {
            var notifications = await _notificationRepository.GetUnsentNotifications();
            return _mapper.Map<IEnumerable<NotificationResponseDto>>(notifications);
        }

        public async Task<IEnumerable<NotificationResponseDto>> GetNotificationsByPriority(PriorityEnum priority, CancellationToken cancellationToken = default)
        {
            var notifications = await _notificationRepository.GetNotificationsByPriority(priority);
            return _mapper.Map<IEnumerable<NotificationResponseDto>>(notifications);
        }

        public async Task<bool> MarkNotificationAsSent(long notificationId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(notificationId, nameof(notificationId));

            var notification = await _notificationRepository.GetByIdAsync(notificationId, cancellationToken);
            if (notification is null)
            {
                _logger.LogWarning("Notification with ID {NotificationId} does not exist.", notificationId);
                throw new ArgumentException($"Notification with ID {notificationId} does not exist.");
            }

            return await _notificationRepository.MarkNotificationAsSent(notificationId);
        }

        public async Task<IEnumerable<NotificationResponseDto>> GetNotificationsByDateRange(DateTime start, DateTime end, CancellationToken cancellationToken = default)
        {
            ValidateDateRange(start, end);

            var notifications = await _notificationRepository.GetNotificationsByDateRange(start, end);
            return _mapper.Map<IEnumerable<NotificationResponseDto>>(notifications);
        }

        public async Task<IEnumerable<NotificationResponseDto>> GetLatestNotifications(int count, CancellationToken cancellationToken = default)
        {
            ValidateCount(count, nameof(count));

            var notifications = await _notificationRepository.GetLatestNotifications(count);
            return _mapper.Map<IEnumerable<NotificationResponseDto>>(notifications);
        }
    }
}
