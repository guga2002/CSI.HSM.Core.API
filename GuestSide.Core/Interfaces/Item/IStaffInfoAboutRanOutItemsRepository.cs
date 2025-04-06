using Core.Core.Entities.Enums;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Item
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