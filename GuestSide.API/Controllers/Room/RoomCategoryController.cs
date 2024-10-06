using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Room;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Room;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Room
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomCategoryController : CSIControllerBase<RoomCategoryDto,long,RoomCategory>
    {
        public RoomCategoryController(IService<RoomCategoryDto, long, RoomCategory> service):base(service) { }
        
        
    }
}
