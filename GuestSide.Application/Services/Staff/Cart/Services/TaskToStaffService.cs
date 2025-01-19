using AutoMapper;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Application.Interface.Staff.Cart;
using GuestSide.Application.Interface.Task.Task;
using GuestSide.Application.Services;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.Cart.Services
{
    public class TaskToStaffService : GenericService<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>, ITaskToStaffService
    {
        public TaskToStaffService(IMapper mapper, IGenericRepository<TaskToStaff> repository, ILogger<GenericService<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>> logger) : base(mapper, repository, logger)
        {
        }
    }
}
