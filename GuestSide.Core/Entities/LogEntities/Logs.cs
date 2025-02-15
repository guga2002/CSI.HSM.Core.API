using System.ComponentModel.DataAnnotations;
using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.LogEntities
{
    [Table("Logs", Schema = "CSI")]
    [Index(nameof(LoggerId))] 
    [Index(nameof(LogLevel))] 
    [Index(nameof(CorrelationId))] 
    [Index(nameof(Timestamp))] 
    [Index(nameof(IsEmergency))] 
    public class Logs : AbstractEntity
    {
        /// <summary>
        /// Logger, user who triggered the action
        /// </summary>
        public long? LoggerId { get; set; }

        [StringLength(50)]
        public required string LogLevel { get; set; }

        [StringLength(500)]
        public required string Message { get; set; }

        public Guid CorrelationId { get; set; } 

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "nvarchar(max)")] 
        public required string Exception { get; set; }

        [StringLength(45)] 
        public string? IpAddress { get; set; }

        [StringLength(255)] 
        public string? Source { get; set; }

        public bool IsEmergency { get; set; } = false;

        [StringLength(100)]
        public string? RequestId { get; set; } 

        [Column(TypeName = "nvarchar(max)")]
        public string? StackTrace { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
