using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Enums;
using Domain.Core.Entities.Staff;

namespace Core.Application.Interface.Staff.StaffSupport;

public interface IStaffSupportService : IService<StaffSupportDto, StaffSupportResponseDto, long, StaffSupport>,
    IAdditionalFeatures<StaffSupportDto, StaffSupportResponseDto, long, StaffSupport>
{
    /// <summary>
    /// Get support tickets by staff ID.
    /// </summary>
    Task<IEnumerable<StaffSupportResponseDto>> GetTicketsByStaffIdAsync(long staffId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get support tickets by priority.
    /// </summary>
    Task<IEnumerable<StaffSupportResponseDto>> GetTicketsByPriorityAsync(PriorityEnum priority,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get support tickets by status.
    /// </summary>
    Task<IEnumerable<StaffSupportResponseDto>> GetTicketsByStatusAsync(StatusEnum status,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get support tickets by category.
    /// </summary>
    Task<IEnumerable<StaffSupportResponseDto>> GetTicketsByCategoryAsync(string category,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Get recent support tickets.
    /// </summary>
    Task<IEnumerable<StaffSupportResponseDto>> GetRecentTicketsAsync(int days,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Update ticket status.
    /// </summary>
    Task<bool> UpdateTicketStatusAsync(long ticketId, StatusEnum newStatus,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Resolve a support ticket with resolution notes.
    /// </summary>
    Task<bool> ResolveTicketAsync(long ticketId, string resolutionNotes,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Add attachments to a support ticket.
    /// </summary>
    Task<bool> AddAttachmentToTicketAsync(long ticketId, List<string> attachments,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// CountOpenTicketsAsync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> CountOpenTicketsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// CountResolvedTicketsAsync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> CountResolvedTicketsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// CountHighPriorityTicketsAsync
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> CountHighPriorityTicketsAsync(CancellationToken cancellationToken = default);

}
