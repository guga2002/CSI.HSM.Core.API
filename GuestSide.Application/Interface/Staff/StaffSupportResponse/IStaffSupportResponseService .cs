﻿using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Staff;

namespace Core.Application.Interface.Staff;

public interface IStaffSupportResponseService : IService<StaffSupportResponseRequestDto, StaffSupportResponseResponseDto, long, StaffSupportResponse>,
    IAdditionalFeatures<StaffSupportResponseRequestDto, StaffSupportResponseResponseDto, long, StaffSupportResponse>
{
    /// <summary>
    /// Get support responses by ticket ID.
    /// </summary>
    Task<IEnumerable<StaffSupportResponseResponseDto>> GetResponsesByTicketIdAsync(long ticketId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get support team responses.
    /// </summary>
    Task<IEnumerable<StaffSupportResponseResponseDto>> GetSupportTeamResponsesAsync(bool isFromSupportTeam, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get recent responses.
    /// </summary>
    Task<IEnumerable<StaffSupportResponseResponseDto>> GetRecentResponsesAsync(int days, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update response message.
    /// </summary>
    Task<bool> UpdateResponseMessageAsync(long responseId, string newMessage, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add attachments to a response.
    /// </summary>
    Task<bool> AddAttachmentToResponseAsync(long responseId, List<string> attachments, CancellationToken cancellationToken = default);

    /// <summary>
    /// Mark response as from support team.
    /// </summary>
    Task<bool> MarkResponseAsSupportTeamAsync(long responseId, bool isFromSupportTeam, CancellationToken cancellationToken = default);

    /// <summary>
    /// Count responses per ticket.
    /// </summary>
    Task<int> CountResponsesPerTicketAsync(long ticketId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Count support team responses.
    /// </summary>
    Task<int> CountSupportTeamResponsesAsync(CancellationToken cancellationToken = default);
}
