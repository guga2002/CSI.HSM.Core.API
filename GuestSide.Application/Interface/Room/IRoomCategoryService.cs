using Core.Application.Interface.GenericContracts;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Core.Entities.Room;

namespace GuestSide.Application.Interface.Room;

public interface IRoomCategoryService:IService<RoomCategoryDto,RoomCategoryResponseDto,long,RoomCategory>,
    IAdditionalFeatures<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>
{
}
