using AutoMapper;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Staff;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.Staff.StaffSupportResponse;
using Core.Application.Services;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.StaffSupportResponse.Service;

public class StaffSupportResponseService : GenericService<StaffSupportResponseRequestDto, StaffSupportResponseResponseDto, long, Common.Data.Entities.Staff.StaffSupportResponse>, IStaffSupportResponseService
{
    private readonly IStaffSupportResponseRepository _staffSupportResponseRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<StaffSupportResponseService> _logger;

    public StaffSupportResponseService(
        IMapper mapper,
        IStaffSupportResponseRepository staffSupportResponseRepository,
        ILogger<StaffSupportResponseService> logger,
        IGenericRepository<Common.Data.Entities.Staff.StaffSupportResponse> repository,
        IAdditionalFeaturesRepository<Common.Data.Entities.Staff.StaffSupportResponse> additionalFeatures)
        : base(mapper, repository, logger, additionalFeatures)
    {
        _staffSupportResponseRepository = staffSupportResponseRepository;
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

    public async Task<IEnumerable<StaffSupportResponseResponseDto>> GetResponsesByTicketIdAsync(long ticketId, CancellationToken cancellationToken = default)
    {
        ValidatePositiveId(ticketId, nameof(ticketId));

        var responses = await _staffSupportResponseRepository.GetResponsesByTicketIdAsync(ticketId, cancellationToken);
        return _mapper.Map<IEnumerable<StaffSupportResponseResponseDto>>(responses);
    }

    public async Task<IEnumerable<StaffSupportResponseResponseDto>> GetSupportTeamResponsesAsync(bool isFromSupportTeam, CancellationToken cancellationToken = default)
    {
        var responses = await _staffSupportResponseRepository.GetSupportTeamResponsesAsync(isFromSupportTeam, cancellationToken);
        return _mapper.Map<IEnumerable<StaffSupportResponseResponseDto>>(responses);
    }

    public async Task<IEnumerable<StaffSupportResponseResponseDto>> GetRecentResponsesAsync(int days, CancellationToken cancellationToken = default)
    {
        if (days <= 0)
        {
            _logger.LogWarning("Days must be a positive number.");
            throw new ArgumentException("Days must be greater than zero.");
        }

        var responses = await _staffSupportResponseRepository.GetRecentResponsesAsync(days, cancellationToken);
        return _mapper.Map<IEnumerable<StaffSupportResponseResponseDto>>(responses);
    }

    public async Task<bool> UpdateResponseMessageAsync(long responseId, string newMessage, CancellationToken cancellationToken = default)
    {
        ValidatePositiveId(responseId, nameof(responseId));
        ValidateStringInput(newMessage, nameof(newMessage));

        return await _staffSupportResponseRepository.UpdateResponseMessageAsync(responseId, newMessage, cancellationToken);
    }

    public async Task<bool> AddAttachmentToResponseAsync(long responseId, List<string> attachments, CancellationToken cancellationToken = default)
    {
        ValidatePositiveId(responseId, nameof(responseId));
        ValidateAttachments(attachments);

        return await _staffSupportResponseRepository.AddAttachmentToResponseAsync(responseId, attachments, cancellationToken);
    }

    public async Task<bool> MarkResponseAsSupportTeamAsync(long responseId, bool isFromSupportTeam, CancellationToken cancellationToken = default)
    {
        ValidatePositiveId(responseId, nameof(responseId));

        return await _staffSupportResponseRepository.MarkResponseAsSupportTeamAsync(responseId, isFromSupportTeam, cancellationToken);
    }

    public async Task<int> CountResponsesPerTicketAsync(long ticketId, CancellationToken cancellationToken = default)
    {
        ValidatePositiveId(ticketId, nameof(ticketId));

        return await _staffSupportResponseRepository.CountResponsesPerTicketAsync(ticketId, cancellationToken);
    }

    public async Task<int> CountSupportTeamResponsesAsync(CancellationToken cancellationToken = default)
    {
        return await _staffSupportResponseRepository.CountSupportTeamResponsesAsync(cancellationToken);
    }
}
