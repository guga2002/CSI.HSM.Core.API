using AutoMapper;
using GuestSide.Application.DTOs.Room;
using GuestSide.Application.Interface.Room;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Room.Service
{
    public class RoomService:GenericService<RoomsDto,long,Rooms>,IRoomService
    {
        public RoomService(IMapper mapper,
                             IGenericRepository<Rooms> repos,
                             ILogger<GenericService<RoomsDto, long, Rooms>> logger)
            : base(mapper, repos, logger) { }
    }
}
