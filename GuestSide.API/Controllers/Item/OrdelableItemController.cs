using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Core.Entities.Item;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Item;

[Route("api/[controller]")]
[ApiController]
public class OrdelableItemController : CSIControllerBase<OrderableItemDto, OrderableItemResponseDto, long, OrderableItem>
{
    public OrdelableItemController(IService<OrderableItemDto, OrderableItemResponseDto, long, OrderableItem> serviceProvider, IAdditionalFeatures<OrderableItemDto, OrderableItemResponseDto, long, OrderableItem> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
