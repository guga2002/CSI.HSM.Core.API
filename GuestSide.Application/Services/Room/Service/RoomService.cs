using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Hotel;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Application.Interface.Room;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Room;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Room.Service;

public class RoomService : GenericService<RoomsDto, RoomsResponseDto, long, Rooms>, IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;
    public RoomService(IRoomRepository roomRepository, IMapper mapper, 
        IGenericRepository<Rooms> repository, 
        ILogger<GenericService<RoomsDto, RoomsResponseDto, long, Rooms>> logger, 
        IAdditionalFeaturesRepository<Rooms> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
        _mapper= mapper;
        _roomRepository= roomRepository;
    }

    public async Task<HotelResponse> GetHotelForRoom(long roomId)
    {
        var res=await _roomRepository.GetHotelForRoom(roomId);
        if(res is not null)
        {
            return _mapper.Map<HotelResponse>(res);
        }
        throw new ArgumentException("No data exist");
    }

    public async Task<RoomsResponseDto> GetRoomDetails(long roomId)
    {
        var res = await _roomRepository.GetRoomDetails(roomId);
        if (res is not null)
        {
            return _mapper.Map<RoomsResponseDto>(res);
        }
        throw new ArgumentException("No data exist");
    }
}
