using Domain.Core.Entities.Enums;
using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Staff
{
    public interface IStaffIncidentRepository : IGenericRepository<StaffIncident>
    {
        Task<IEnumerable<StaffIncident>> GetIncidentsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffIncident>> GetIncidentsBySeverityAsync(PriorityEnum severity, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffIncident>> GetIncidentsByStatusAsync(StatusEnum status, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffIncident>> GetIncidentsByTypeAsync(long incidentTypeId, CancellationToken cancellationToken = default);
        Task<IEnumerable<StaffIncident>> GetUrgentIncidentsAsync(CancellationToken cancellationToken = default);

        Task<bool> UpdateIncidentStatusAsync(long incidentId, StatusEnum newStatus, CancellationToken cancellationToken = default);
        Task<bool> ResolveIncidentAsync(long incidentId, string resolutionNotes, CancellationToken cancellationToken = default);

        Task<int> CountOpenIncidentsAsync(CancellationToken cancellationToken = default);
        Task<int> CountResolvedIncidentsAsync(CancellationToken cancellationToken = default);
        Task<int> CountUrgentIncidentsAsync(CancellationToken cancellationToken = default);
    }
}