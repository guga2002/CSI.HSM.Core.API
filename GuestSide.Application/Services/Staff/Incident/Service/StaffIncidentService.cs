using AutoMapper;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff;
using Core.Core.Entities.Staff;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Staff;
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

        public async Task<IEnumerable<StaffIncidentResponseDto>> GetIncidentsBySeverityAsync(string severity, CancellationToken cancellationToken = default)
        {
            ValidateStringInput(severity, nameof(severity));

            var incidents = await _staffIncidentRepository.GetIncidentsBySeverityAsync(severity, cancellationToken);
            return _mapper.Map<IEnumerable<StaffIncidentResponseDto>>(incidents);
        }

        public async Task<IEnumerable<StaffIncidentResponseDto>> GetIncidentsByStatusAsync(string status, CancellationToken cancellationToken = default)
        {
            ValidateStringInput(status, nameof(status));

            var incidents = await _staffIncidentRepository.GetIncidentsByStatusAsync(status, cancellationToken);
            return _mapper.Map<IEnumerable<StaffIncidentResponseDto>>(incidents);
        }

        public async Task<IEnumerable<StaffIncidentResponseDto>> GetIncidentsByTypeAsync(string incidentType, CancellationToken cancellationToken = default)
        {
            ValidateStringInput(incidentType, nameof(incidentType));

            var incidents = await _staffIncidentRepository.GetIncidentsByTypeAsync(incidentType, cancellationToken);
            return _mapper.Map<IEnumerable<StaffIncidentResponseDto>>(incidents);
        }

        public async Task<IEnumerable<StaffIncidentResponseDto>> GetUrgentIncidentsAsync(CancellationToken cancellationToken = default)
        {
            var incidents = await _staffIncidentRepository.GetUrgentIncidentsAsync(cancellationToken);
            return _mapper.Map<IEnumerable<StaffIncidentResponseDto>>(incidents);
        }

        public async Task<bool> UpdateIncidentStatusAsync(long incidentId, string newStatus, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(incidentId, nameof(incidentId));
            ValidateStringInput(newStatus, nameof(newStatus));

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
