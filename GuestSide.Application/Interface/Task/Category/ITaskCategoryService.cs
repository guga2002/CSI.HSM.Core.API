using GuestSide.Application.DTOs.Staff;
using GuestSide.Application.DTOs.Task;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Entities.Task;

namespace GuestSide.Application.Interface.Staff.Category
{
    public interface ITaskCategoryService:IService<TaskCategoryDto,long, TaskCategory>
    {
    }
}
