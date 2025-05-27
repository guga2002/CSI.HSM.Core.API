using Common.Data.Entities.Notification;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.GenericContracts;

namespace Core.Application.Interface.Notification
{
    public interface IStaffNotificationService : IService<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification>,
        IAdditionalFeatures<StafNotificationDto, StafNotificationResponseDto, long, StaffNotification>
    {
        /// <summary>
        /// Mark a staff notification as read/unread.
        /// </summary>
        Task<StafNotificationResponseDto?> MarkStaffNotificationAsRead(long staffId, long notificationId, bool unread = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get unread notifications for a staff member.
        /// </summary>
        Task<IEnumerable<StafNotificationResponseDto>> GetUnreadNotificationsByStaffId(long staffId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get important notifications for a staff member.
        /// </summary>
        Task<IEnumerable<StafNotificationResponseDto>> GetImportantNotificationsByStaffId(long staffId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a specific staff notification.
        /// </summary>
        Task<bool> DeleteStaffNotification(long staffId, long notificationId, CancellationToken cancellationToken = default);

        /// <summary>
        /// get all notification by staffid
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        Task<IEnumerable<StafNotificationResponseDto>> GetStaffNotifications(long staffId);
    }
}