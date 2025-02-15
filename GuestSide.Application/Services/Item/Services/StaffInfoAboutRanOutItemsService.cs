using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Item;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Item
{
    public class StaffInfoAboutRanOutItemsService : GenericService<StaffInfoAboutRanOutItemsDto, StaffInfoAboutRanOutItemsResponseDto, long, StaffInfoAboutRanOutItems>, IStaffInfoAboutRanOutItemsService
    {
        private readonly IStaffInfoAboutRanOutItemsRepository _staffInfoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<StaffInfoAboutRanOutItemsService> _logger;

        public StaffInfoAboutRanOutItemsService(
            IMapper mapper,
            IStaffInfoAboutRanOutItemsRepository staffInfoRepository,
            ILogger<StaffInfoAboutRanOutItemsService> logger,
            IGenericRepository<StaffInfoAboutRanOutItems> repository,
            IAdditionalFeaturesRepository<StaffInfoAboutRanOutItems> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _staffInfoRepository = staffInfoRepository;
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

        public async Task<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>> GetRequestsByStaffIdAsync(long staffId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(staffId, nameof(staffId));

            var requests = await _staffInfoRepository.GetRequestsByStaffIdAsync(staffId, cancellationToken);
            return _mapper.Map<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>(requests);
        }

        public async Task<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>> GetRequestsByPriorityAsync(RefillPriority priority, CancellationToken cancellationToken = default)
        {
            var requests = await _staffInfoRepository.GetRequestsByPriorityAsync(priority, cancellationToken);
            return _mapper.Map<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>(requests);
        }

        public async Task<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>> GetUnresolvedRequestsAsync(CancellationToken cancellationToken = default)
        {
            var requests = await _staffInfoRepository.GetUnresolvedRequestsAsync(cancellationToken);
            return _mapper.Map<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>(requests);
        }

        public async Task<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>> GetUrgentRequestsAsync(CancellationToken cancellationToken = default)
        {
            var requests = await _staffInfoRepository.GetUrgentRequestsAsync(cancellationToken);
            return _mapper.Map<IEnumerable<StaffInfoAboutRanOutItemsResponseDto>>(requests);
        }

        public async Task<bool> MarkRequestResolvedAsync(long requestId, string? notes, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(requestId, nameof(requestId));

            var request = await _staffInfoRepository.GetRequestsByStaffIdAsync(requestId, cancellationToken);
            if (request is null)
            {
                _logger.LogWarning("Request with ID {Id} does not exist.", requestId);
                throw new ArgumentException($"Request with ID {requestId} does not exist.");
            }

            return await _staffInfoRepository.MarkRequestResolvedAsync(requestId, notes, cancellationToken);
        }

        public async Task<int> CountUnresolvedRequestsAsync(CancellationToken cancellationToken = default)
        {
            return await _staffInfoRepository.CountUnresolvedRequestsAsync(cancellationToken);
        }

        public async Task<int> CountHighPriorityRequestsAsync(CancellationToken cancellationToken = default)
        {
            return await _staffInfoRepository.CountHighPriorityRequestsAsync(cancellationToken);
        }
    }
}
