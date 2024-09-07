namespace GuestSide.Application.DTOs.FeedBacks
{
    public class FeedbackDto
    {
        public required string Title { get; set; }

        //Detailed content of the feedback
        public required string Content { get; set; }

        public int Rating { get; set; }

        public DateTime FeedbackDate { get; set; }

        public long TasksId { get; set; }
    }
}
