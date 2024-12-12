using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Core.Entities.Staff;

namespace GuestSide.Application.Interface.Staff.Cart
{
    public  interface ICartToStaffService : IService<CartToStaffDto,CartToStaffResponseDto,long,TaskToStaff>
    {
    }
}
