using GuestSide.API.CustomExtendControllerBase;
using GuestSide.Application.DTOs.Item;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Item;
using Microsoft.AspNetCore.Mvc;

namespace GuestSide.API.Controllers.Item
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : CSIControllerBase<CartDto,long,Cart>
    {
        public CartController(IService<CartDto, long, Cart>service):base(service) { }

        //add more services  or  inject  other  features

    }
}
