using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.Incident;
using Domain.Core.Entities.Enums;
using Domain.Core.Entities.Staff;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Staff;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.Incident.Service
{
    public class StaffIncidentService : GenericService<StaffIncidentDto, StaffIncidentResponseDto, long, StaffIncident>, IStaffIncidentService
    {
        private readonly IStaffIncidentRepository _staffIncidentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<StaffIncidentService> _logger;

        public StaffIncidentService(
            IMapper mapper,
            IStaffIncidentRepository staffIncidentRepository,
            ILogger<StaffIncidentService> logger,
            IGenericRepository<StaffIncident> repository,
            IAdditionalFeaturesRepository<StaffIncident> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _staffIncidentRepository = staffIncidentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        private void ValidatePositiveId(long id, string paramName)
        {
            if (id <= 0)
            {
                _logger.LogWarning("{ParameterName} must be a positive number.", paramName);
                throw new ArgumentException($"{paramName} must be greater than zero.", paramName);
            }
        }

        private void ValidateStringInput(string input, string paramName)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 3)
            {
                _logger.LogWarning("{ParameterName} must be at least 3 characters long.", paramName);
                throw new ArgumentException($"{paramName} must be at least 3 characters long.");
            }
        }

        public async Task<IEnumerable<StaffIncidentResponseDto>> GetIncidentsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            var incidents = await _staffIncidentRepository.GetIncidentsByStaffIdAsync(staffId, cancellationToken);
            return _mapper.Map<IEnumerable<StaffIncidentResponseDto>>(incidents);
        }

        public async Task<IEnumerable<StaffIncidentResponseDto>> GetIncidentsBySeverityAsync(PriorityEnum severity, CancellationToken cancellationToken = default)
        {
            var incidents = await _staffIncidentRepository.GetIncidentsBySeverityAsync(severity, cancellationToken);
            return _mapper.Map<IEnumerable<StaffIncidentResponseDto>>(incidents);
        }

        public async Task<IEnumerable<StaffIncidentResponseDto>> GetIncidentsByStatusAsync(StatusEnum status, CancellationToken cancellationToken = default)
        {
            var incidents = await _staffIncidentRepository.GetIncidentsByStatusAsync(status, cancellationToken);
            return _mapper.Map<IEnumerable<StaffIncidentResponseDto>>(incidents);
        }

        public async Task<IEnumerable<StaffIncidentResponseDto>> GetIncidentsByTypeAsync(long incidentTypeId, CancellationToken cancellationToken = default)
        {
            var incidents = await _staffIncidentRepository.GetIncidentsByTypeAsync(incidentTypeId, cancellationToken);
            return _mapper.Map<IEnumerable<StaffIncidentResponseDto>>(incidents);
        }

        public async Task<IEnumerable<StaffIncidentResponseDto>> GetUrgentIncidentsAsync(CancellationToken cancellationToken = default)
        {
            var incidents = await _staffIncidentRepository.GetUrgentIncidentsAsync(cancellationToken);
            return _mapper.Map<IEnumerable<StaffIncidentResponseDto>>(incidents);
        }

        public async Task<bool> UpdateIncidentStatusAsync(long incidentId, StatusEnum newStatus, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(incidentId, nameof(incidentId));

            var incident = await _staffIncidentRepository.GetIncidentsByStaffIdAsync(incidentId, cancellationToken);
            if (incident is null)
            {
                _logger.LogWarning("Incident with ID {Id} does not exist.", incidentId);
                throw new ArgumentException($"Incident with ID {incidentId} does not exist.");
            }

            return await _staffIncidentRepository.UpdateIncidentStatusAsync(incidentId, newStatus, cancellationToken);
        }

        public async Task<bool> ResolveIncidentAsync(long incidentId, string resolutionNotes, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(incidentId, nameof(incidentId));
            ValidateStringInput(resolutionNotes, nameof(resolutionNotes));

            return await _staffIncidentRepository.ResolveIncidentAsync(incidentId, resolutionNotes, cancellationToken);
        }

        public async Task<int> CountOpenIncidentsAsync(CancellationToken cancellationToken = default)
        {
            return await _staffIncidentRepository.CountOpenIncidentsAsync(cancellationToken);
        }

        public async Task<int> CountResolvedIncidentsAsync(CancellationToken cancellationToken = default)
        {
            return await _staffIncidentRepository.CountResolvedIncidentsAsync(cancellationToken);
        }

        public async Task<int> CountUrgentIncidentsAsync(CancellationToken cancellationToken = default)
        {
            return await _staffIncidentRepository.CountUrgentIncidentsAsync(cancellationToken);
        }
    }
}
