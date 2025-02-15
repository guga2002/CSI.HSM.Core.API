using Core.Core.Entities.Staff;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Staff
{
    public interface IStaffIncidentRepository : IGenericRepository<StaffIncident>
    {
        Task<IEnumerable<StaffIncident>> GetIncidentsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffIncident>> GetIncidentsBySeverityAsync(string severity, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffIncident>> GetIncidentsByStatusAsync(string status, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffIncident>> GetIncidentsByTypeAsync(string incidentType, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffIncident>> GetUrgentIncidentsAsync(CancellationToken cancellationToken = default);

        Task<bool> UpdateIncidentStatusAsync(long incidentId, string newStatus, CancellationToken cancellationToken = default);
        Task<bool> ResolveIncidentAsync(long incidentId, string resolutionNotes, CancellationToken cancellationToken = default);

        Task<int> CountOpenIncidentsAsync(CancellationToken cancellationToken = default);
        Task<int> CountResolvedIncidentsAsync(CancellationToken cancellationToken = default);
        Task<int> CountUrgentIncidentsAsync(CancellationToken cancellationToken = default);
    }
}