namespace Core.Application.DTOs.Response.Task;

public class TaskLogResponse
{
    public long Id { get; set; }
    public bool IsActive { get; set; }
    public long TaskId { get; set; }
    public required string Action { get; set; }
    public required string PerformedBy { get; set; }
    public string? Notes { get; set; }
    public DateTime Timestamp { get; set; }
}
