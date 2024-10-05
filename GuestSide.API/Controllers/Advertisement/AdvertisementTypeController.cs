using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Advertisments;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Advertisement
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementTypeController : CSIControllerBase<AdvertisementTypeDto, long, AdvertisementType>
    {
        public AdvertisementTypeController(IService<AdvertisementTypeDto, long, AdvertisementType> serviceProvider) : base(serviceProvider)
        {
        }

        //add more services  or  inject  other  features
    }
}
