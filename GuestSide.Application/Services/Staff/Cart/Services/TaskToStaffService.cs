using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.CustomExceptions;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Application.Interface.Staff.Cart;
using GuestSide.Application.Services;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Staff;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Staff.Cart.Services;

public class TaskToStaffService : GenericService<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>, ITaskToStaffService
{
    private readonly IMapper _map;
    ITaskToStaffRepository _taskToStaffRepository;

    public TaskToStaffService(IMapper mapper,
        IGenericRepository<TaskToStaff> repository, 
        ILogger<GenericService<TaskToStaffDto, TaskToStaffResponseDto, long, TaskToStaff>> logger,
        IAdditionalFeaturesRepository<TaskToStaff> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
    }

    public async Task<TaskToStaffResponseDto> GetByTaskId(long taskId)
    {
        var result = await _taskToStaffRepository.GetByTaskId(taskId);
        if (result == null) throw new NotFoundException("Data not found");

        return _map.Map<TaskToStaffResponseDto>(result);
    }
}
