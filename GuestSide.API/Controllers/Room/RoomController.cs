using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Room;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Room;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Room
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : CSIControllerBase<RoomsDto,long,Rooms>
    {
        public RoomController(IService<RoomsDto, long, Rooms> service):base(service) { }
        
        
    }
}
