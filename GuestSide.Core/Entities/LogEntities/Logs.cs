using GuestSide.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.LogEntities
{
    [Table("Logs", Schema = "CSI")]
    public class Logs:AbstractEntity
    {
        public required string LogLevel { get; set; }
        public required string Message { get; set; }
        public Guid CorrelationId { get; set; }
        public DateTime Timestamp { get; set; }
        public required string Exception { get; set; }
        public string? Source { get; set; }
        public bool IsEmergency { get; set; } = false;//if  set true, will sent  emergency message to SA (Raisa, Guga) using SMTP
    }
}
