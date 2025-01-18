namespace GuestSide.Application.DTOs.Response.Task;

public class TaskStatusResponseDto
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public long LanguageId { get; set; }
}
