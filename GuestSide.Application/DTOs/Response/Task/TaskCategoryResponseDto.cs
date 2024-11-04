namespace GuestSide.Application.DTOs.Response.Task
{
    public class TaskCategoryResponseDto
    {
        public long Id { get; set; }
        public required string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
