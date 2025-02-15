using Core.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Room;

[Table("QRCodes", Schema = "CSI")]
public class QRCode : AbstractEntity
{
    [StringLength(100)]
    public required string Code { get; set; }

    [StringLength(100)]
    public string? Text { get; set; }

    public required byte[] QrCodeImage { get; set; }

    public DateTime GeneratedDate { get; set; }

    [ForeignKey(nameof(Room))]
    public long RoomId { get; set; }

    public virtual Rooms? Room { get; set; }
}
