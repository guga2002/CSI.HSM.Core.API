using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Item;

namespace Core.Application.Interface.Item;

public interface IItemCategoryService : IService<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory>,
    IAdditionalFeatures<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory>
{
}
