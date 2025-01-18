namespace GuestSide.Application.DTOs.Request.Task;

public class TaskCategoryDto
{
    public required string CategoryName { get; set; }
    public string? Description { get; set; }
    public long LanguageId { get; set; }
}
