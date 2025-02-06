using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Core.Entities.Task;

namespace GuestSide.Application.DTOs.Request.Item;

public class CartDto
{
    public long GuestId { get; set; }

    public virtual IEnumerable<TaskDto>? Tasks { get; set; }

    public long LanguageId { get; set; }

    public bool IsCompleted { get; set; }
}
