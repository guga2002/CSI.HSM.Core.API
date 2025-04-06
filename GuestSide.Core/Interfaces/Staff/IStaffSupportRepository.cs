using Core.Core.Entities.Enums;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Staff
{
    public interface IStaffSupportRepository : IGenericRepository<StaffSupport>
    {
        Task<IEnumerable<StaffSupport>> GetTicketsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffSupport>> GetTicketsByPriorityAsync(PriorityEnum priority, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffSupport>> GetTicketsByStatusAsync(StatusEnum status, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffSupport>> GetTicketsByCategoryAsync(string category, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffSupport>> GetRecentTicketsAsync(int days, CancellationToken cancellationToken = default);

        Task<bool> UpdateTicketStatusAsync(long ticketId, StatusEnum newStatus, CancellationToken cancellationToken = default);
        Task<bool> ResolveTicketAsync(long ticketId, string resolutionNotes, CancellationToken cancellationToken = default);
        Task<bool> AddAttachmentToTicketAsync(long ticketId, List<string> attachments, CancellationToken cancellationToken = default);

        Task<int> CountOpenTicketsAsync(CancellationToken cancellationToken = default);
        Task<int> CountResolvedTicketsAsync(CancellationToken cancellationToken = default);
        Task<int> CountHighPriorityTicketsAsync(CancellationToken cancellationToken = default);
    }
}