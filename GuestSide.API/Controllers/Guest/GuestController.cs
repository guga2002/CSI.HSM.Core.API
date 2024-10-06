using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.NewFolder;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Guest;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Guest
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : CSIControllerBase<GuestDto,long,Guests>
    {
        public GuestController(IService<GuestDto, long, Guests>service):base(service)
        {
        }
        //add more services  or  inject  other  features
    }
}
