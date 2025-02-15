namespace Core.Application.DTOs.Request.LogModel;

public class LogDto
{
    public required string LogLevel { get; set; }
    public required string Message { get; set; }
    public Guid CorrelationId { get; set; }
    public DateTime Timestamp { get; set; }
    public required string Exception { get; set; }
    public string? Source { get; set; }
    public bool IsEmergency { get; set; } = false;
}
