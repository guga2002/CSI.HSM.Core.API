using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Core.Entities.Item;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Item;

[Route("api/[controller]")]
[ApiController]
public class ItemCategoryController : CSIControllerBase<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory>
{
    public ItemCategoryController(IService<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory> serviceProvider, IAdditionalFeatures<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
