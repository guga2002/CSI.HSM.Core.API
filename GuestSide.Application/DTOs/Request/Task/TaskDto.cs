namespace GuestSide.Application.DTOs.Request.Task;

public class TaskDto
{
    public required string Title { get; set; }

    public required string Description { get; set; }
    public long LanguageId { get; set; }

    public long CartId { get; set; }

    public string? Note { get; set; }
}
