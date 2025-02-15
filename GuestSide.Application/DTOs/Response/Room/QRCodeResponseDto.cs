using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Application.DTOs.Response.Room;

public class QRCodeResponseDto
{
    public long Id { get; set; }

    public required string Code { get; set; }

    public string? Text { get; set; }

    public required byte[] QrCodeImage { get; set; }

    public DateTime GeneratedDate { get; set; } 

    public DateTime? ExpirationDate { get; set; }

    public int ScannedCount { get; set; }


    public DateTime UpdatedAt { get; set; } 

    public long RoomId { get; set; }

}
