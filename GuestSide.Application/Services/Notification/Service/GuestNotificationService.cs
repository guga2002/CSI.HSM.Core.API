using AutoMapper;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.Notification;
using Core.Core.Entities.Notification;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Notification;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Notification.Service
{
    public class GuestNotificationService : GenericService<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>, IGuestNotificationService
    {
        private readonly IGuestNotificationRepository _guestNotificationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GuestNotificationService> _logger;

        public GuestNotificationService(
            IMapper mapper,
            IGuestNotificationRepository guestNotificationRepository,
            ILogger<GuestNotificationService> logger,
            IGenericRepository<GuestNotification> repository,
            IAdditionalFeaturesRepository<GuestNotification> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _guestNotificationRepository = guestNotificationRepository;
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

        public async Task<GuestNotificationResponseDto?> MarkGuestNotificationAsRead(long guestId, long notificationId, bool unread = false, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));
            ValidatePositiveId(notificationId, nameof(notificationId));

            var notification = await _guestNotificationRepository.MarkGuestNotificationAsRead(guestId, notificationId, unread);
            return notification is null ? null : _mapper.Map<GuestNotificationResponseDto>(notification);
        }

        public async Task<IEnumerable<GuestNotificationResponseDto>> GetNotificationsByGuestId(long guestId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));

            var notifications = await _guestNotificationRepository.GetNotificationsByGuestId(guestId);
            return _mapper.Map<IEnumerable<GuestNotificationResponseDto>>(notifications);
        }

        public async Task<IEnumerable<GuestNotificationResponseDto>> GetUnreadNotificationsByGuestId(long guestId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));

            var notifications = await _guestNotificationRepository.GetUnreadNotificationsByGuestId(guestId);
            return _mapper.Map<IEnumerable<GuestNotificationResponseDto>>(notifications);
        }

        public async Task<IEnumerable<GuestNotificationResponseDto>> GetImportantNotificationsByGuestId(long guestId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));

            var notifications = await _guestNotificationRepository.GetImportantNotificationsByGuestId(guestId);
            return _mapper.Map<IEnumerable<GuestNotificationResponseDto>>(notifications);
        }

        public async Task<bool> DeleteGuestNotification(long guestId, long notificationId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));
            ValidatePositiveId(notificationId, nameof(notificationId));

            var notification = await _guestNotificationRepository.GetByIdAsync(notificationId, cancellationToken);
            if (notification is null)
            {
                _logger.LogWarning("Notification with ID {NotificationId} does not exist.", notificationId);
                throw new ArgumentException($"Notification with ID {notificationId} does not exist.");
            }

            if (notification.GuestId != guestId)
            {
                _logger.LogWarning("Notification ID {NotificationId} does not belong to Guest ID {GuestId}.", notificationId, guestId);
                throw new UnauthorizedAccessException($"Notification ID {notificationId} does not belong to Guest ID {guestId}.");
            }

            return await _guestNotificationRepository.DeleteGuestNotification(guestId, notification.NotificationId);
        }
    }
}
