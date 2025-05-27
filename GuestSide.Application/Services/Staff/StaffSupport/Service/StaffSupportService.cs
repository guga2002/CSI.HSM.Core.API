using AutoMapper;
using Common.Data.Entities.Enums;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Staff;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.StaffSupport;
using Core.Application.Services;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.StaffSupport.Service
{
    public class StaffSupportService : GenericService<StaffSupportDto, StaffSupportResponseDto, long, Common.Data.Entities.Staff.StaffSupport>, IStaffSupportService
    {
        private readonly IStaffSupportRepository _staffSupportRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<StaffSupportService> _logger;

        public StaffSupportService(
            IMapper mapper,
            IStaffSupportRepository staffSupportRepository,
            ILogger<StaffSupportService> logger,
            IGenericRepository<Common.Data.Entities.Staff.StaffSupport> repository,
            IAdditionalFeaturesRepository<Common.Data.Entities.Staff.StaffSupport> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _staffSupportRepository = staffSupportRepository;
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

        private void ValidateAttachments(List<string> attachments)
        {
            if (attachments == null || attachments.Count == 0)
            {
                _logger.LogWarning("Attachments list cannot be empty.");
                throw new ArgumentException("Attachments list cannot be empty.");
            }
        }

        public async Task<IEnumerable<StaffSupportResponseDto>> GetTicketsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            var tickets = await _staffSupportRepository.GetTicketsByStaffIdAsync(staffId, cancellationToken);
            return _mapper.Map<IEnumerable<StaffSupportResponseDto>>(tickets);
        }

        public async Task<IEnumerable<StaffSupportResponseDto>> GetTicketsByPriorityAsync(PriorityEnum priority, CancellationToken cancellationToken = default)
        {
            var tickets = await _staffSupportRepository.GetTicketsByPriorityAsync(priority, cancellationToken);
            return _mapper.Map<IEnumerable<StaffSupportResponseDto>>(tickets);
        }

        public async Task<IEnumerable<StaffSupportResponseDto>> GetTicketsByStatusAsync(StatusEnum status, CancellationToken cancellationToken = default)
        {
            var tickets = await _staffSupportRepository.GetTicketsByStatusAsync(status, cancellationToken);
            return _mapper.Map<IEnumerable<StaffSupportResponseDto>>(tickets);
        }

        public async Task<IEnumerable<StaffSupportResponseDto>> GetTicketsByCategoryAsync(string category, CancellationToken cancellationToken = default)
        {
            ValidateStringInput(category, nameof(category));

            var tickets = await _staffSupportRepository.GetTicketsByCategoryAsync(category, cancellationToken);
            return _mapper.Map<IEnumerable<StaffSupportResponseDto>>(tickets);
        }

        public async Task<IEnumerable<StaffSupportResponseDto>> GetRecentTicketsAsync(int days, CancellationToken cancellationToken = default)
        {
            if (days <= 0)
            {
                _logger.LogWarning("Days must be a positive number.");
                throw new ArgumentException("Days must be greater than zero.");
            }

            var tickets = await _staffSupportRepository.GetRecentTicketsAsync(days, cancellationToken);
            return _mapper.Map<IEnumerable<StaffSupportResponseDto>>(tickets);
        }

        public async Task<bool> UpdateTicketStatusAsync(long ticketId, StatusEnum newStatus, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(ticketId, nameof(ticketId));

            return await _staffSupportRepository.UpdateTicketStatusAsync(ticketId, newStatus, cancellationToken);
        }

        public async Task<bool> ResolveTicketAsync(long ticketId, string resolutionNotes, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(ticketId, nameof(ticketId));
            ValidateStringInput(resolutionNotes, nameof(resolutionNotes));

            return await _staffSupportRepository.ResolveTicketAsync(ticketId, resolutionNotes, cancellationToken);
        }

        public async Task<bool> AddAttachmentToTicketAsync(long ticketId, List<string> attachments, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(ticketId, nameof(ticketId));
            ValidateAttachments(attachments);

            return await _staffSupportRepository.AddAttachmentToTicketAsync(ticketId, attachments, cancellationToken);
        }

        public async Task<int> CountOpenTicketsAsync(CancellationToken cancellationToken = default)
        {
            return await _staffSupportRepository.CountOpenTicketsAsync(cancellationToken);
        }

        public async Task<int> CountResolvedTicketsAsync(CancellationToken cancellationToken = default)
        {
            return await _staffSupportRepository.CountResolvedTicketsAsync(cancellationToken);
        }

        public async Task<int> CountHighPriorityTicketsAsync(CancellationToken cancellationToken = default)
        {
            return await _staffSupportRepository.CountHighPriorityTicketsAsync(cancellationToken);
        }
    }
}
