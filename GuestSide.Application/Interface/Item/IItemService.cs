using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Item;

namespace Core.Application.Interface.Item;

public interface IItemService : IService<ItemDto, ItemResponseDto, long, Items>,
    IAdditionalFeatures<ItemDto, ItemResponseDto, long, Items>
{
}
