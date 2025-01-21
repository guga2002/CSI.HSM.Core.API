using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Core.Entities.Item;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Item;

[Route("api/[controller]")]
[ApiController]
public class CartController : CSIControllerBase<CartDto, CartResponseDto, long, Cart>
{
    public CartController(IService<CartDto, CartResponseDto, long, Cart> serviceProvider, IAdditionalFeatures<CartDto, CartResponseDto, long, Cart> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
