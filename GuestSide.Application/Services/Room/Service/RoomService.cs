using AutoMapper;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Application.Interface.Room;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Room.Service
{
    public class RoomService:GenericService<RoomsDto,RoomsResponseDto,long,Rooms>,IRoomService
    {
        public RoomService(IMapper mapper,
                             IGenericRepository<Rooms> repos,
                             ILogger<GenericService<RoomsDto, RoomsResponseDto, long, Rooms>> logger)
            : base(mapper, repos, logger) { }
    }
}
