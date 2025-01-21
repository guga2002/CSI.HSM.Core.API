using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using GuestSide.Core.Entities.Item;

namespace Core.Application.Interface.Item;

public interface IOrderableItemService:IService<OrderableItemDto,OrderableItemResponseDto,long,OrderableItem>,
    IAdditionalFeatures<OrderableItemDto, OrderableItemResponseDto, long, OrderableItem>
{
}
