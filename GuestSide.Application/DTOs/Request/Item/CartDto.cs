using GuestSide.Core.Entities.Task;

namespace GuestSide.Application.DTOs.Request.Item;

public class CartDto
{
    public long GuestId { get; set; }

    public virtual IEnumerable<Tasks>? Tasks { get; set; }

    public long LanguageId { get; set; }
}
