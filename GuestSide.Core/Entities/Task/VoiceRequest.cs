using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Task;

[Table("VoiceRequests", Schema = "CSI")]
public class VoiceRequest : AbstractEntity
{
    public long GuestId { get; set; }

    public string? VoiceText { get; set; }

    public bool IsProcessed { get; set; }
}
