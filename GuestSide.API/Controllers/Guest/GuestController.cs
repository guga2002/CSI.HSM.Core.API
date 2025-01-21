using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Guest;
using GuestSide.Application.DTOs.Response.Guest;
using GuestSide.Core.Entities.Guest;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Guest;

[ApiController]
[Route("api/[controller]")]
public class GuestController : CSIControllerBase<GuestDto, GuestResponseDto, long, Guests>
{
    public GuestController(IService<GuestDto, GuestResponseDto, long, Guests> serviceProvider, IAdditionalFeatures<GuestDto, GuestResponseDto, long, Guests> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
