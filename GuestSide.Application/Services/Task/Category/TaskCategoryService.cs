using AutoMapper;
using GuestSide.Application.DTOs.Task;
using GuestSide.Application.Interface.Staff.Category;
using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Task.Category
{
    public class TaskCategoryService : GenericService<TaskCategoryDto, long, TaskCategory>, ITaskCategoryService
    {
        public TaskCategoryService(IMapper mapper, IGenericRepository<TaskCategory> repository, ILogger<GenericService<TaskCategoryDto, long, TaskCategory>> logger) : base(mapper, repository, logger)
        {
        }
    }
}
