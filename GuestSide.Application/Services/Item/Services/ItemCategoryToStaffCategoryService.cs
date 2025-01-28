using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.Services;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Item.Services;

public class ItemCategoryToStaffCategoryService :
    GenericService<ItemCategoryToStaffCategoryDto, ItemCategoryToStaffCategoryResponseDto, long, ItemCategoryToStaffCategory>,
    IItemCategoryToStaffCategoryService
{
    public ItemCategoryToStaffCategoryService(IMapper mapper, 
        IGenericRepository<ItemCategoryToStaffCategory> repository, 
        ILogger<GenericService<ItemCategoryToStaffCategoryDto, ItemCategoryToStaffCategoryResponseDto, long, ItemCategoryToStaffCategory>> logger, 
        IAdditionalFeaturesRepository<ItemCategoryToStaffCategory> additioalFeatures) 
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
