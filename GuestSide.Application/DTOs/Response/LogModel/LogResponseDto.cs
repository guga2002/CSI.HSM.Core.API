using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.LogModel;

public class LogResponseDto : AbstractResponse
{
    public long? LoggerId { get; set; }

    public required string LogLevel { get; set; }

    public required string Message { get; set; }

    public Guid CorrelationId { get; set; }

    public DateTime Timestamp { get; set; }

    public required string Exception { get; set; }

    public string? IpAddress { get; set; }

    public string? Source { get; set; }

    public bool IsEmergency { get; set; } = false;

    public string? RequestId { get; set; }

    public string? StackTrace { get; set; }
}
