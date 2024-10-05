using AutoMapper;
using GuestSide.Application.DTOs.Room;
using GuestSide.Application.Interface.Room;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Room.Service
{
    public class RoomCategoryService:GenericService<RoomCategoryDto,long,RoomCategory>,IRoomCategoryService
    {
        public RoomCategoryService(IMapper mapper,
                             IGenericRepository<RoomCategory> repos,
                             ILogger<GenericService<RoomCategoryDto, long, RoomCategory>> logger)
            : base(mapper, repos, logger) { }
    }
}
