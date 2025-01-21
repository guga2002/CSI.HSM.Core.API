using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Application.Interface.Room;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Room.Service;

public class RoomCategoryService : GenericService<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>, IRoomCategoryService
{
    public RoomCategoryService(IMapper mapper, 
        IGenericRepository<RoomCategory> repository,
        ILogger<GenericService<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>> logger, 
        IAdditionalFeaturesRepository<RoomCategory> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
