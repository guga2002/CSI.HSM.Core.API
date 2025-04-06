using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Enums;
using Core.Core.Entities.Item;

namespace Core.Application.Interface.Item
{
    public interface IStaffInfoAboutRanOutItemsService : IService<StaffInfoAboutRanOutItemsDto, StaffInfoAboutRanOutItemsResponseDto, long, StaffInfoAboutRanOutItems>,
        IAdditionalFeatures<StaffInfoAboutRanOutItemsDto, StaffInfoAboutRanOutItemsResponseDto, long, StaffInfoAboutRanOutItems>
    {
        /// <summary>
        /// Get refill requests by staff ID.
        /// </summary>
        Task<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>> GetRequestsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get refill requests by priority.
        /// </summary>
        Task<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>> GetRequestsByPriorityAsync(PriorityEnum priority, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get unresolved refill requests.
        /// </summary>
        Task<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>> GetUnresolvedRequestsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get urgent refill requests.
        /// </summary>
        Task<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>> GetUrgentRequestsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Mark a request as resolved with optional notes.
        /// </summary>
        Task<bool> MarkRequestResolvedAsync(long requestId, string? notes, CancellationToken cancellationToken = default);

        /// <summary>
        /// Count unresolved refill requests.
        /// </summary>
        Task<int> CountUnresolvedRequestsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Count high-priority refill requests.
        /// </summary>
        Task<int> CountHighPriorityRequestsAsync(CancellationToken cancellationToken = default);
    }
}
