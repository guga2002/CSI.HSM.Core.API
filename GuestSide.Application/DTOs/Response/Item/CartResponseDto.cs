using Core.Application.DTOs.Response.Task;

namespace Core.Application.DTOs.Response.Item;

public class CartResponseDto
{
    public long Id { get; set; }

    public long GuestId { get; set; }

    public long LanguageId { get; set; }

    public decimal SubTotal { get; set; }

    public bool IsComplete { get; set; }

    public IEnumerable<TaskResponseDto> Tasks { get; set; }
}

