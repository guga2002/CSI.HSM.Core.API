using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Item;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Item;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Item
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : CSIControllerBase<ItemDto,long,Items>
    {
        public ItemController(IService<ItemDto, long, Items> service):base(service) { }
        
        
    }
}
