using AutoMapper;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Application.Interface.Staff.Cart;
using GuestSide.Application.Interface.Task.Task;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Staff.Cart
{
    public class TaskStatusService : GenericService<CartToStaffDto,CartToStaffResponseDto, long, CartToStaff>, ICartToStaffService
    {
        public TaskStatusService(IMapper mapper, IGenericRepository<CartToStaff> repository, ILogger<GenericService<CartToStaffDto,CartToStaffResponseDto, long, CartToStaff>> logger) : base(mapper, repository, logger)
        {
        }
    }
}
