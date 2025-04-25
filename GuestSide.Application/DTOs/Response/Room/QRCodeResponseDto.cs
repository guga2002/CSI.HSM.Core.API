using Core.Application.DTOs.Response;

namespace Core.Application.DTOs.Response.Room;

public class QRCodeResponseDto : AbstractResponse
{
    public required string Code { get; set; }

    public string? Text { get; set; }

    public required byte[] QrCodeImage { get; set; }

    public DateTime GeneratedDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public int ScannedCount { get; set; }

    public long RoomId { get; set; }
}
