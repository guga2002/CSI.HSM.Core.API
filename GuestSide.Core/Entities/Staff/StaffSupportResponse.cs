using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Core.Core.Entities.Staff
{
    [Table("StaffSupportResponses", Schema = "CSI")]
    [Index(nameof(TicketId))] 
    [Index(nameof(ResponseDate))] 
    [Index(nameof(IsFromSupportTeam))] 
    public class StaffSupportResponse : AbstractEntity
    {
        [ForeignKey(nameof(StaffSupport))]
        public long TicketId { get; set; }

        public virtual StaffSupport? StaffSupport { get; set; } // Virtual for lazy loading


        [StringLength(150)]
        public string? ResponderName { get; set; } // Stores responder name (in case responder is external)

        [StringLength(1000)]
        public string? ResponseMessage { get; set; } // Detailed message response

        public bool IsFromSupportTeam { get; set; } = false; // Indicates if response is from support team

        public DateTime ResponseDate { get; set; } = DateTime.UtcNow; // Automatically set when response is created

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "nvarchar(max)")] 
        public string? AttachmentUrlsSerialized { get; set; }

        [NotMapped]
        public List<string>? AttachmentUrls
        {
            get => AttachmentUrlsSerialized == null ? new List<string>() : JsonSerializer.Deserialize<List<string>>(AttachmentUrlsSerialized);
            set => AttachmentUrlsSerialized = value == null ? null : JsonSerializer.Serialize(value);
        }
    }
}
