using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;
using GuestSide.Core.Data;
using GuestSide.Core.Entities.Advertisements;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Advertisement;

[ApiController]
[Route("api/[controller]")]
public class AdvertisementController : CSIControllerBase<AdvertismentDto,AdvertismentResponseDto, long, Advertisements>
{
    public AdvertisementController(IService<AdvertismentDto,AdvertismentResponseDto, long, Advertisements> serviceProvider,GuestSideDb db,IAdditionalFeatures<AdvertismentDto, AdvertismentResponseDto, long, Advertisements> feat) : base(serviceProvider,feat)
    {
    }
}
