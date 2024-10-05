using GuestSide.Application.DTOs.Room;
using GuestSide.Core.Entities.Room;

namespace GuestSide.Application.Interface.Room
{
    public interface IRoomCategoryService:IService<RoomCategoryDto,long,RoomCategory>
    {
    }
}
