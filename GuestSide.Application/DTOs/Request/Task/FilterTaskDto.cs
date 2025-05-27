using Common.Data.Entities.Enums;

namespace Core.Application.DTOs.Request.Task;

public class FilterTaskDto
{
    public StatusEnum? Status { get; set; }

    public PriorityEnum? Priority { get; set; }

    public bool? IsCompleted { get; set; }

    //shualedi roca task daregistrirda
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
