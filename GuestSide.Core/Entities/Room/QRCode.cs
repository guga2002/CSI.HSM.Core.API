using Domain.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities.Room;

[Table("QRCodes", Schema = "CSI")]
[Index(nameof(Code), IsUnique = true)]
[Index(nameof(RoomId))]
public class QRCode : AbstractEntity
{
    [StringLength(100)]
    public required string Code { get; set; }

    [StringLength(255)]
    public string? Text { get; set; }

    public required byte[] QrCodeImage { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public int ScannedCount { get; set; } = 0;

    [ForeignKey(nameof(Room))]
    public long RoomId { get; set; }

    public virtual Room? Room { get; set; }
}