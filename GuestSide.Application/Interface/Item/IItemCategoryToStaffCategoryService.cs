using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Item;

namespace Core.Application.Interface.Item;

public interface IItemCategoryToStaffCategoryService: IService<ItemCategoryToStaffCategoryDto, ItemCategoryToStaffCategoryResponseDto, long, ItemCategoryToStaffCategory>,
    IAdditionalFeatures<ItemCategoryToStaffCategoryDto, ItemCategoryToStaffCategoryResponseDto, long, ItemCategoryToStaffCategory>
{
}
