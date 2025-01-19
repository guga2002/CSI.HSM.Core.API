using AutoMapper;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Application.Interface.Task.Category;
using GuestSide.Application.Services;
using GuestSide.Core.Entities.Task;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Task.Category.Services
{
    public class TaskCategoryService : GenericService<TaskCategoryDto, TaskCategoryResponseDto, long, TaskCategory>, ITaskCategoryService
    {
        public TaskCategoryService(IMapper mapper, IGenericRepository<TaskCategory> repository, ILogger<GenericService<TaskCategoryDto, TaskCategoryResponseDto, long, TaskCategory>> logger) : base(mapper, repository, logger)
        {
        }
    }
}
