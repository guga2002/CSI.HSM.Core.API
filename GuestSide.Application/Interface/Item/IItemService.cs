using Core.Application.Interface.GenericContracts;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Core.Entities.Item;

namespace GuestSide.Application.Interface.Item;

public interface IItemService:IService<ItemDto,ItemResponseDto,long,Items>,
    IAdditionalFeatures<ItemDto, ItemResponseDto, long, Items>
{
}
