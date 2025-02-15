using Core.Application.DTOs.Request.Task;

namespace Core.Application.DTOs.Request.Item;

public class CartDto
{
    public long GuestId { get; set; }

    public virtual IEnumerable<TaskDto>? Tasks { get; set; }

    public long LanguageId { get; set; }

    public bool IsCompleted { get; set; }
}
