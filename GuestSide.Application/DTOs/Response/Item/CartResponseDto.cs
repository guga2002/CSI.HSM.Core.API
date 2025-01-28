using GuestSide.Application.DTOs.Request.Task;

namespace GuestSide.Application.DTOs.Response.Item;

public class CartResponseDto
{
    public long Id { get; set; }

    public long GuestId { get; set; }

    public long LanguageId { get; set; }

    public decimal SubTotal { get; set; }
    public IEnumerable<TaskDto> Tasks { get; set; }
}

