using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Hotel;
using GuestSide.Application.DTOs.Response.Hotel;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Hotel;

[Route("api/[controller]")]
[ApiController]
public class HotelController : CSIControllerBase<HotelRequestDto, HotelResponse, long, GuestSide.Core.Entities.Hotel.Hotel>
{
    public HotelController(IService<HotelRequestDto, HotelResponse, long, Core.Entities.Hotel.Hotel> serviceProvider, IAdditionalFeatures<HotelRequestDto, HotelResponse, long, Core.Entities.Hotel.Hotel> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
