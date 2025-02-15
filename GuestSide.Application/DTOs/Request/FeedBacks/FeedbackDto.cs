namespace Core.Application.DTOs.Request.FeedBacks;

public class FeedbackDto
{
    public required string Title { get; set; }

    public required string Content { get; set; }

    public string? LanguageCode { get; set; }

    public long TaskId { get; set; }
}
