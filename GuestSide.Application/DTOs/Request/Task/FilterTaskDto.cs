using Core.Core.Entities.Task;
using TaskStatus = Core.Core.Entities.Task.TaskStatus;

namespace Core.Application.DTOs.Request.Task;

public class FilterTaskDto
{
    public TaskStatus? Status { get; set; }

    public TaskPriority? Priority { get; set; }

    public bool? IsCompleted {  get; set; }

    //shualedi roca task daregistrirda
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
