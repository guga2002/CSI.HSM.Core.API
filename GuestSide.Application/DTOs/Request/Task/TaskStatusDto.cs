namespace GuestSide.Application.DTOs.Request.Task
{
    public class TaskStatusDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
