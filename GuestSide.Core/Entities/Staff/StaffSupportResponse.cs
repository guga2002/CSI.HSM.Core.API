using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;

namespace Core.Core.Entities.Staff;

[Table("StaffSupportResponses",Schema = "CSI")]
public class StaffSupportResponse:AbstractEntity
{
    [ForeignKey(nameof(StaffMemberSupport))]
    public long TicketId { get; set; }
    public string? ResponderName { get; set; }
    public string? ResponseMessage { get; set; }
    public DateTime ResponseDate { get; set; }
    public bool IsFromSupportTeam { get; set; }
    public IEnumerable<string>? AttachmentUrls { get; set; }
    public StaffSupport? StaffMemberSupport { get; set; }
}
