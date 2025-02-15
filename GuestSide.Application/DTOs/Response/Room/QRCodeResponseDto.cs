using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs.Response.Room;

public class QRCodeResponseDto
{
    public long Id { get; set; }

    public required string Code { get; set; }

    public string? Text { get; set; }

    public required byte[] QrCodeImage { get; set; }

    [DataType(DataType.Date)]
    public DateTime GeneratedDate { get; set; }

    public long RoomId { get; set; }

}
