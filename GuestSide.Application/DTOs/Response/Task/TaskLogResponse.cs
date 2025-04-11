using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.Task;

public class TaskLogResponse : AbstractResponse
{
    public long TaskId { get; set; }

    public required string Action { get; set; }

    public required string PerformedBy { get; set; }

    public string? Notes { get; set; }
}
