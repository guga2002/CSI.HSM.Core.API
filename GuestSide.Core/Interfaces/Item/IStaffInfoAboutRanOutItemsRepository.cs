using Domain.Core.Entities.Enums;
using Domain.Core.Entities.Item;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Item
{
    public interface IStaffInfoAboutRanOutItemsRepository : IGenericRepository<StaffInfoAboutRanOutItems>
    {
        Task<IEnumerable<StaffInfoAboutRanOutItems>> GetRequestsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffInfoAboutRanOutItems>> GetRequestsByPriorityAsync(PriorityEnum priority, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffInfoAboutRanOutItems>> GetUnresolvedRequestsAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffInfoAboutRanOutItems>> GetUrgentRequestsAsync(CancellationToken cancellationToken = default);

        Task<bool> MarkRequestResolvedAsync(long requestId, string? notes, CancellationToken cancellationToken = default);

        Task<int> CountUnresolvedRequestsAsync(CancellationToken cancellationToken = default);
        Task<int> CountHighPriorityRequestsAsync(CancellationToken cancellationToken = default);
    }
}