using System.ComponentModel.DataAnnotations;
using Core.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.LogEntities;

[Table("Logs", Schema = "CSI")]
public class Logs : AbstractEntity
{
    /// <summary>
    /// Logger, user who drop the action
    /// </summary>
    public long? LoggerId { get; set; }
    [StringLength(100)]
    public required string LogLevel { get; set; }
    [StringLength(100)]
    public required string Message { get; set; }
    public Guid CorrelationId { get; set; }
    public DateTime Timestamp { get; set; }
    [StringLength(100)]
    public required string Exception { get; set; }
    [StringLength(100)]
    public string? IpAddress { get; set; }
    [StringLength(100)]
    public string? Source { get; set; }
    public bool IsEmergency { get; set; } = false;//if  set true, will sent  emergency message to SA (Raisa, Guga) using SMTP
}
