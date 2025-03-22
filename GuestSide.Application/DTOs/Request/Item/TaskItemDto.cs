namespace Core.Application.DTOs.Request.Item;

public class TaskItemDto
{
    public long TaskId { get; set; }

    public long ItemId { get; set; }

    public int Quantity { get; set; }

    public string? Notes { get; set; }
}
