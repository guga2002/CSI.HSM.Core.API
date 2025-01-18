using GuestSide.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Room;

[Table("QRCodes", Schema = "CSI")]
public class QRCode:AbstractEntity
{
    public required string Code { get; set; }

    public string? Text { get; set; }

    public required byte[] QrCodeImage { get; set; }

    public DateTime GeneratedDate {  get; set; }

    [ForeignKey(nameof(Room))]
    public long RoomId {  get; set; }

    public virtual Rooms? Room{ get; set; }
}
