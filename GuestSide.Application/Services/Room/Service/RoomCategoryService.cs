using AutoMapper;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.Room;
using Core.Core.Entities.Room;
using Core.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Room.Service;

public class RoomCategoryService : GenericService<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>, IRoomCategoryService
{
    public RoomCategoryService(IMapper mapper,
        IGenericRepository<RoomCategory> repository,
        ILogger<GenericService<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>> logger,
        IAdditionalFeaturesRepository<RoomCategory> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
