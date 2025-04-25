namespace Core.Application.DTOs.Request.Task;

public class CommentDto
{
    public long StaffId { get; set; }

    public long TaskId { get; set; }

    public string? Text { get; set; }
}
