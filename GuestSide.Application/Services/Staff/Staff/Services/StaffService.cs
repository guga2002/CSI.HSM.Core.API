using AutoMapper;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Application.Interface.Staff.staf;
using GuestSide.Application.Services;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.Staff.Services
{
    public class TasksService : GenericService<StaffDto, StaffResponseDto, long, Staffs>, IStaffService
    {
        public TasksService(IMapper mapper, IGenericRepository<Staffs> repository, ILogger<GenericService<StaffDto, StaffResponseDto, long, Staffs>> logger) : base(mapper, repository, logger)
        {
        }
    }
}
