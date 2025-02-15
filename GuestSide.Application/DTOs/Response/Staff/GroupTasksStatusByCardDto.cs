using Core.Application.DTOs.Response.Task;

namespace Core.Application.DTOs.Response.Staff;

public class GroupTasksStatusByCardDto
{
    public string Status { get; set; }

    public IEnumerable<TaskResponseDto> Tasks { get; set; }
}
