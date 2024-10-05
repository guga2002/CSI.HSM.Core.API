using GuestSide.Application.DTOs.Item;
using GuestSide.Core.Entities.Item;

namespace GuestSide.Application.Interface.Item
{
    public interface IItemCategoryService:IService<ItemCategoryDto,long,ItemCategory>
    {
    }
}
