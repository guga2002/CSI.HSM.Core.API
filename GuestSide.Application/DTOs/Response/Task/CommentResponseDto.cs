namespace Core.Application.DTOs.Response.Task;

public class CommentResponseDto : AbstractResponse
{
    public long? StaffId { get; set; }

    public long? GuestId { get; set; }

    public long TaskId { get; set; }

    public string? Text { get; set; }

    public virtual TaskResponseDto? Tasks { get; set; }
}
