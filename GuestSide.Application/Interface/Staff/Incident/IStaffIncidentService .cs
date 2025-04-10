using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Domain.Core.Entities.Enums;
using Domain.Core.Entities.Staff;

namespace Core.Application.Interface.Staff.Incident
{
    public interface IStaffIncidentService : IService<StaffIncidentDto, StaffIncidentResponseDto, long, StaffIncident>,
        IAdditionalFeatures<StaffIncidentDto, StaffIncidentResponseDto, long, StaffIncident>
    {
        /// <summary>
        /// Get incidents by staff ID.
        /// </summary>
        Task<IEnumerable<StaffIncidentResponseDto>> GetIncidentsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get incidents filtered by severity.
        /// </summary>
        Task<IEnumerable<StaffIncidentResponseDto>> GetIncidentsBySeverityAsync(PriorityEnum severity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get incidents filtered by status.
        /// </summary>
        Task<IEnumerable<StaffIncidentResponseDto>> GetIncidentsByStatusAsync(StatusEnum status, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get incidents by type.
        /// </summary>
        Task<IEnumerable<StaffIncidentResponseDto>> GetIncidentsByTypeAsync(long incidentTypeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get urgent incidents.
        /// </summary>
        Task<IEnumerable<StaffIncidentResponseDto>> GetUrgentIncidentsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Update incident status.
        /// </summary>
        Task<bool> UpdateIncidentStatusAsync(long incidentId, StatusEnum newStatus, CancellationToken cancellationToken = default);

        /// <summary>
        /// Resolve an incident with resolution notes.
        /// </summary>
        Task<bool> ResolveIncidentAsync(long incidentId, string resolutionNotes, CancellationToken cancellationToken = default);

        /// <summary>
        /// Count open incidents.
        /// </summary>
        Task<int> CountOpenIncidentsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Count resolved incidents.
        /// </summary>
        Task<int> CountResolvedIncidentsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Count urgent incidents.
        /// </summary>
        Task<int> CountUrgentIncidentsAsync(CancellationToken cancellationToken = default);
    }
}
