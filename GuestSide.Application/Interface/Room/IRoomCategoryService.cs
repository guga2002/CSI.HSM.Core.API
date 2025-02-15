using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Room;

namespace Core.Application.Interface.Room;

public interface IRoomCategoryService : IService<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>,
    IAdditionalFeatures<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>
{
}
