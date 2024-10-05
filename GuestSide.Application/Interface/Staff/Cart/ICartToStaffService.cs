using GuestSide.Application.DTOs.Staff;
using GuestSide.Core.Entities.Staff;

namespace GuestSide.Application.Interface.Staff.Cart
{
    public  interface ICartToStaffService : IService<CartToStaffDto,long,CartToStaff>
    {
    }
}
