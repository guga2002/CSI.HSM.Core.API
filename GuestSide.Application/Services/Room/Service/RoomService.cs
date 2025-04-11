using AutoMapper;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Hotel;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.Room;
using Domain.Core.Entities.Room;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.Room;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Room.Service
{
    public class RoomService : GenericService<RoomsDto, RoomsResponseDto, long, Core.Entities.Room.Room>, IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomService> _logger;

        public RoomService(
            IRoomRepository roomRepository,
            IMapper mapper,
            IGenericRepository<Core.Entities.Room.Room> repository,
            ILogger<RoomService> logger,
            IAdditionalFeaturesRepository<Core.Entities.Room.Room> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
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

        private void ValidateString(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _logger.LogWarning("{ParameterName} cannot be empty or whitespace.", paramName);
                throw new ArgumentException($"{paramName} cannot be empty or whitespace.", paramName);
            }
        }

        private void ValidatePrice(decimal price, string paramName)
        {
            if (price <= 0)
            {
                _logger.LogWarning("{ParameterName} must be greater than zero.", paramName);
                throw new ArgumentException($"{paramName} must be greater than zero.", paramName);
            }
        }

        public async Task<IEnumerable<RoomsResponseDto>> GetAvailableRooms(long hotelId, long categoryId, int maxOccupancy, decimal maxPrice, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(hotelId, nameof(hotelId));
            ValidatePositiveId(categoryId, nameof(categoryId));
            ValidatePrice(maxPrice, nameof(maxPrice));

            var rooms = await _roomRepository.GetAvailableRooms(hotelId, categoryId, maxOccupancy, maxPrice);
            return _mapper.Map<IEnumerable<RoomsResponseDto>>(rooms);
        }

        public async Task<bool> MarkRoomAsUnavailable(long roomId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(roomId, nameof(roomId));

            var room = await _roomRepository.GetByIdAsync(roomId, cancellationToken);
            if (room is null)
            {
                _logger.LogWarning("Room with ID {RoomId} does not exist.", roomId);
                throw new ArgumentException($"Room with ID {roomId} does not exist.");
            }

            return await _roomRepository.MarkRoomAsUnavailable(roomId);
        }

        public async Task<bool> UpdateRoomPrice(long roomId, decimal newPrice, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(roomId, nameof(roomId));
            ValidatePrice(newPrice, nameof(newPrice));

            var room = await _roomRepository.GetByIdAsync(roomId, cancellationToken);
            if (room is null)
            {
                _logger.LogWarning("Room with ID {RoomId} does not exist.", roomId);
                throw new ArgumentException($"Room with ID {roomId} does not exist.");
            }

            return await _roomRepository.UpdateRoomPrice(roomId, newPrice);
        }

        public async Task<IEnumerable<RoomsResponseDto>> GetRoomsByHotel(long hotelId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(hotelId, nameof(hotelId));

            var rooms = await _roomRepository.GetRoomsByHotel(hotelId);
            return _mapper.Map<IEnumerable<RoomsResponseDto>>(rooms);
        }

        public async Task<HotelResponse> GetHotelForRoomAsync(long roomId)
        {
            var rooms = await _roomRepository.GetHotelForRoomAsync(roomId);
            return _mapper.Map<HotelResponse>(rooms);
        }
    }
}
