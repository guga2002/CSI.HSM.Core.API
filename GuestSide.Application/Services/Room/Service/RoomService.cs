using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Application.Interface.Room;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Room.Service;

public class RoomService : GenericService<RoomsDto, RoomsResponseDto, long, Rooms>, IRoomService
{
    public RoomService(IMapper mapper, 
        IGenericRepository<Rooms> repository, 
        ILogger<GenericService<RoomsDto, RoomsResponseDto, long, Rooms>> logger, 
        IAdditionalFeaturesRepository<Rooms> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
