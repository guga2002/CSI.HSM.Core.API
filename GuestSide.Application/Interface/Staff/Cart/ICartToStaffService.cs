﻿using Core.Application.Interface.GenericContracts;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Core.Entities.Staff;

namespace GuestSide.Application.Interface.Staff.Cart
{
    public  interface ICartToStaffService : IService<TaskToStaffDto,TaskToStaffResponseDto,long,TaskToStaff>
    {
    }
}
