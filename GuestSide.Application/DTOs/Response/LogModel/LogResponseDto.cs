namespace Core.Application.DTOs.Response.LogModel;

public class LogResponseDto
{
    public long Id { get; set; }
    public required string LogLevel { get; set; }
    public required string Message { get; set; }
    public Guid CorrelationId { get; set; }
    public DateTime Timestamp { get; set; }
    public required string Exception { get; set; }
    public string? Source { get; set; }
    public bool IsEmergency { get; set; }
}
