using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;
using GuestSide.Core.Entities.Advertisments;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Advertisement;

[Route("api/[controller]")]
[ApiController]
public class AdvertisementTypeController : CSIControllerBase<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType>
{
    public AdvertisementTypeController(IService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType> serviceProvider, IAdditionalFeatures<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType> additionalFeatures) : base(serviceProvider, additionalFeatures)
    {
    }
}
