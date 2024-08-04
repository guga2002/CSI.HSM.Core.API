using GuestSide.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.LogEntities
{
    [Table("Logs")]
    public class Logs:AbstractEntity
    {
        public required string LogLevel { get; set; }
        public required string Message { get; set; }

        public DateTime Timestamp { get; set; }

        public required string Exception { get; set; }
        public string? Source { get; set; }
    }
}
