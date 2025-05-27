using AutoMapper;
using Common.Data.Entities.Notification;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Notification;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.Notification;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Notification.Service
{
    public class StaffNotificationService : GenericService<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification>, IStaffNotificationService
    {
        private readonly IStaffNotificationRepository _staffNotificationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<StaffNotificationService> _logger;

        public StaffNotificationService(
            IMapper mapper,
            IStaffNotificationRepository staffNotificationRepository,
            ILogger<StaffNotificationService> logger,
            IGenericRepository<StaffNotification> repository,
            IAdditionalFeaturesRepository<StaffNotification> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _staffNotificationRepository = staffNotificationRepository;
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

        public async Task<StafNotificationResponseDto?> MarkStaffNotificationAsRead(long staffId, long notificationId, bool unread = false, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));
            ValidatePositiveId(notificationId, nameof(notificationId));

            var notification = await _staffNotificationRepository.MarkStaffNotificationAsRead(staffId, notificationId, unread);
            return notification is null ? null : _mapper.Map<StafNotificationResponseDto>(notification);
        }

        public async Task<IEnumerable<StafNotificationResponseDto>> GetUnreadNotificationsByStaffId(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            var notifications = await _staffNotificationRepository.GetUnreadNotificationsByStaffId(staffId);
            return _mapper.Map<IEnumerable<StafNotificationResponseDto>>(notifications);
        }

        public async Task<IEnumerable<StafNotificationResponseDto>> GetImportantNotificationsByStaffId(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            var notifications = await _staffNotificationRepository.GetImportantNotificationsByStaffId(staffId);
            return _mapper.Map<IEnumerable<StafNotificationResponseDto>>(notifications);
        }

        public async Task<bool> DeleteStaffNotification(long staffId, long notificationId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));
            ValidatePositiveId(notificationId, nameof(notificationId));

            var notification = await _staffNotificationRepository.GetByIdAsync(notificationId, cancellationToken);
            if (notification is null)
            {
                _logger.LogWarning("Notification with ID {NotificationId} does not exist.", notificationId);
                throw new ArgumentException($"Notification with ID {notificationId} does not exist.");
            }

            if (notification.StaffId != staffId)
            {
                _logger.LogWarning("Notification ID {NotificationId} does not belong to Staff ID {StaffId}.", notificationId, staffId);
                throw new UnauthorizedAccessException($"Notification ID {notificationId} does not belong to Staff ID {staffId}.");
            }

            return await _staffNotificationRepository.DeleteStaffNotification(staffId, notification.NotificationId);
        }

        public async Task<IEnumerable<StafNotificationResponseDto>> GetStaffNotifications(long staffId)
        {
            ValidatePositiveId(staffId, nameof(staffId));
            var notifications = await _staffNotificationRepository.GetStaffNotifications(staffId);

            return _mapper.Map<IEnumerable<StafNotificationResponseDto>>(notifications);
        }
    }
}
