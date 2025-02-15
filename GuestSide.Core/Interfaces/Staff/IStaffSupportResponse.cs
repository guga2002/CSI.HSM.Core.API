using Core.Core.Entities.Staff;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Staff
{
    public interface IStaffSupportResponseRepository : IGenericRepository<StaffSupportResponse>
    {
        Task<IEnumerable<StaffSupportResponse>> GetResponsesByTicketIdAsync(long ticketId, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffSupportResponse>> GetSupportTeamResponsesAsync(bool isFromSupportTeam, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffSupportResponse>> GetRecentResponsesAsync(int days, CancellationToken cancellationToken = default);

        Task<bool> UpdateResponseMessageAsync(long responseId, string newMessage, CancellationToken cancellationToken = default);
        Task<bool> AddAttachmentToResponseAsync(long responseId, List<string> attachments, CancellationToken cancellationToken = default);
        Task<bool> MarkResponseAsSupportTeamAsync(long responseId, bool isFromSupportTeam, CancellationToken cancellationToken = default);

        Task<int> CountResponsesPerTicketAsync(long ticketId, CancellationToken cancellationToken = default);
        Task<int> CountSupportTeamResponsesAsync(CancellationToken cancellationToken = default);
    }
}