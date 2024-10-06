using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Item;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Item
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryController : CSIControllerBase<ItemCategoryDto,long,ItemCategory>
    {
        public ItemCategoryController(IService<ItemCategoryDto, long, ItemCategory> service):base(service) { }
            
        //add more methods
    }
}
