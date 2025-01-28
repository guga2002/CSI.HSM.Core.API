namespace Core.Application.DTOs.Response.Item;

public class TaskItemResponseDto
{
    public long Id { get; set; }    

    public long TaskId { get; set; }

    public long ItemId { get; set; }

    public int Quantity { get; set; }
}
