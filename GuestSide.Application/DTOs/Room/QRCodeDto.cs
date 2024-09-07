using System.ComponentModel.DataAnnotations;

namespace GuestSide.Application.DTOs.Room
{
    public class QRCodeDto
    {
        public required string Code { get; set; }

        public string? Text { get; set; }

        public required byte[] QrCodeImage { get; set; }

        [DataType(DataType.Date)]
        public DateTime GeneratedDate { get; set; }

        public long RoomId { get; set; }

    }
}
