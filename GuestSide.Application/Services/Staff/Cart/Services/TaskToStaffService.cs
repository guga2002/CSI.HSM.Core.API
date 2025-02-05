using AutoMapper;
using Core.Application.DTOs.Response.Staff;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Sheared;
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
        IAdditionalFeaturesRepository<TaskToStaff> additioalFeatures,
        ITaskToStaffRepository taskToStaffRepository) : base(mapper, repository, logger, additioalFeatures)
    {
        _taskToStaffRepository=taskToStaffRepository;
        _map=mapper;
    }

    public async Task<TaskToStaffResponseDto> GetByTaskId(long taskId)
    {
        var result = await _taskToStaffRepository.GetByTaskId(taskId);
        if (result == null) throw new NotFoundException("Data not found");

        return _map.Map<TaskToStaffResponseDto>(result);
    }

    public async Task<IEnumerable<GroupTasksStatusByCardDto>> GetTasksStatusByCard(long cardId)
    {
        var res=await _taskToStaffRepository.GetTasksStatusByCard(cardId);
        if (res == null) throw new NotFoundException("Data not found");

        return _map.Map<IEnumerable<GroupTasksStatusByCardDto>>(res);
    }
}
