using Core.Application.Interface.GenericContracts;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Task;
using GuestSide.Core.Entities.Task;

namespace GuestSide.Application.Interface.Task.Category;

public interface ITaskCategoryService : IService<TaskCategoryDto,TaskCategoryResponseDto, long, TaskCategory>,
    IAdditionalFeatures<TaskCategoryDto, TaskCategoryResponseDto, long, TaskCategory>
{
}
