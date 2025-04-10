using Domain.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities.LogEntities;

[Table("Logs", Schema = "CSI")]
[Index(nameof(LoggerId))]
[Index(nameof(LogLevel))]
[Index(nameof(CorrelationId))]
[Index(nameof(IsEmergency))]
public class Logs : AbstractEntity
{
    /// <summary>
    /// Logger, user who triggered the action
    /// </summary>
    public long? LoggerId { get; set; }

    public required string LogLevel { get; set; }

    public required string Message { get; set; }

    public Guid CorrelationId { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public required string Exception { get; set; }

    public string? IpAddress { get; set; }

    public string? Source { get; set; }

    public bool IsEmergency { get; set; } = false;

    public string? RequestId { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string? StackTrace { get; set; }
}
