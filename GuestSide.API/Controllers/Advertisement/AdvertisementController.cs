using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Advertisements;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Advertisement
{
    [ApiController]
    public class AdvertisementController : CSIControllerBase<AdvertismentDto, long, Advertisements>
    {
        public AdvertisementController(IService<AdvertismentDto, long, Advertisements> serviceProvider) : base(serviceProvider)
        {
        }

        //add more functions if need also  can inject other interfaces
    }
}
