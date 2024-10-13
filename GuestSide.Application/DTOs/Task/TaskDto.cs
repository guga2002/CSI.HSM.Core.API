namespace GuestSide.Application.DTOs.Task
{
    public class TaskDto
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public long CategoryId { get; set; }

        public long CartId { get; set; }

        public long ItemId { get; set; }
    }
}
