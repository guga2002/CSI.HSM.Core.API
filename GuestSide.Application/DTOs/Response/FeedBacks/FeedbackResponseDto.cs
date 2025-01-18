namespace GuestSide.Application.DTOs.Response.FeedBacks;

public class FeedbackResponseDto
{
    public long Id { get; set; }

    public required string Title { get; set; }

    //Detailed content of the feedback
    public required string Content { get; set; }

    public int Rating { get; set; }

    public DateTime FeedbackDate { get; set; }

    public long TasksId { get; set; }
    public long LanguageId { get; set; }
}
