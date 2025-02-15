using AutoMapper;
using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.Guest;
using Core.Core.Entities.Guest;
using Core.Core.Entities.Room;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Guest;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Core.Application.Services.Guest.Service
{
    public class GuestService : GenericService<GuestDto, GuestResponseDto, long, Guests>, IGuestService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GuestService> _logger;
        private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        private static readonly Regex PhoneRegex = new(@"^\+?[1-9]\d{7,14}$");

        public GuestService(
            IMapper mapper,
            IGuestRepository guestRepository,
            ILogger<GuestService> logger,
            IGenericRepository<Guests> repository,
            IAdditionalFeaturesRepository<Guests> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _guestRepository = guestRepository;
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

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !EmailRegex.IsMatch(email))
            {
                _logger.LogWarning("Invalid email format: {Email}", email);
                throw new ArgumentException("Invalid email format.");
            }
        }

        private void ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || !PhoneRegex.IsMatch(phoneNumber))
            {
                _logger.LogWarning("Invalid phone number format: {PhoneNumber}", phoneNumber);
                throw new ArgumentException("Invalid phone number format.");
            }
        }

        public async Task<RoomsResponseDto?> GetRoomByGuestIdAsync(long guestId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));

            var room = await _guestRepository.GetRoomByGuestIdAsync(guestId);
            return room is null ? null : _mapper.Map<RoomsResponseDto>(room);
        }

        public async Task<GuestResponseDto?> GetGuestDetailsByIdAsync(long guestId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));

            var guest = await _guestRepository.GetGuestDetailsByIdAsync(guestId);
            return guest is null ? null : _mapper.Map<GuestResponseDto>(guest);
        }

        public async Task<IEnumerable<GuestResponseDto>> GetGuestsByRoomIdAsync(long roomId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(roomId, nameof(roomId));

            var guests = await _guestRepository.GetGuestsByRoomIdAsync(roomId);
            return _mapper.Map<IEnumerable<GuestResponseDto>>(guests);
        }

        public async Task<bool> CheckGuestExistsAsync(string email, string phoneNumber, CancellationToken cancellationToken = default)
        {
            ValidateEmail(email);
            ValidatePhoneNumber(phoneNumber);

            return await _guestRepository.CheckGuestExistsAsync(email, phoneNumber);
        }

        public async Task<bool> UpdateGuestStatusAsync(long guestId, long statusId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));
            ValidatePositiveId(statusId, nameof(statusId));

            var guest = await _guestRepository.GetGuestDetailsByIdAsync(guestId);
            if (guest is null)
            {
                _logger.LogWarning("Guest with ID {GuestId} does not exist.", guestId);
                throw new ArgumentException($"Guest with ID {guestId} does not exist.");
            }

            return await _guestRepository.UpdateGuestStatusAsync(guestId, statusId);
        }

        public async Task<IEnumerable<GuestResponseDto>> GetFrequentGuestsAsync(CancellationToken cancellationToken = default)
        {
            var guests = await _guestRepository.GetFrequentGuestsAsync();
            return _mapper.Map<IEnumerable<GuestResponseDto>>(guests);
        }

        public async Task<bool> AssignRoomToGuestAsync(long guestId, long roomId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));
            ValidatePositiveId(roomId, nameof(roomId));

            var guest = await _guestRepository.GetGuestDetailsByIdAsync(guestId);
            if (guest is null)
            {
                _logger.LogWarning("Guest with ID {GuestId} does not exist.", guestId);
                throw new ArgumentException($"Guest with ID {guestId} does not exist.");
            }

            return await _guestRepository.AssignRoomToGuestAsync(guestId, roomId);
        }

        public async Task<bool> DeleteGuestPermanentlyAsync(long guestId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));

            var guest = await _guestRepository.GetGuestDetailsByIdAsync(guestId);
            if (guest is null)
            {
                _logger.LogWarning("Guest with ID {GuestId} does not exist.", guestId);
                throw new ArgumentException($"Guest with ID {guestId} does not exist.");
            }

            return await _guestRepository.DeleteGuestPermanentlyAsync(guestId);
        }
    }
}
