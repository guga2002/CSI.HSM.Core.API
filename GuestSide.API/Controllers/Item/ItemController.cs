using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Core.Entities.Item;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Item;

[Route("api/[controller]")]
[ApiController]
public class ItemController : CSIControllerBase<ItemDto, ItemResponseDto, long, Items>
{
    public ItemController(IService<ItemDto, ItemResponseDto, long, Items> serviceProvider, IAdditionalFeatures<ItemDto, ItemResponseDto, long, Items> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
