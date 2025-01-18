namespace GuestSide.Application.DTOs.Request.FeedBacks;

public class FeedbackDto
{
    public required string Title { get; set; }
    public required string Content { get; set; }

    public long LanguageId { get; set; }

    public long TasksId { get; set; }
}
