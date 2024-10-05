using GuestSide.Application.DTOs.Item;
using GuestSide.Core.Entities.Item;

namespace GuestSide.Application.Interface.Item
{
    public interface ICartService:IService<CartDto,long,Cart>
    {
    }
}
