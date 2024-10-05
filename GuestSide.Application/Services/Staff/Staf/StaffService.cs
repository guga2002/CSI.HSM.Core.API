using AutoMapper;
using GuestSide.Application.DTOs.Staff;
using GuestSide.Application.Interface.Staff.Cart;
using GuestSide.Application.Interface.Staff.staf;
using GuestSide.Application.Interface.Task.Status;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Staff.Staf
{
    public class TasksService : GenericService<StaffDto, long, Staffs>, IStaffService
    {
        public TasksService(IMapper mapper, IGenericRepository<Staffs> repository, ILogger<GenericService<StaffDto, long, Staffs>> logger) : base(mapper, repository, logger)
        {
        }
    }
}
