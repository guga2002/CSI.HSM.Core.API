﻿namespace GuestSide.Application.DTOs.Request.Room
{
    public class QRCodeDto
    {
        public required string Code { get; set; }

        public string? Text { get; set; }

        public required byte[] QrCodeImage { get; set; }

        public DateTime GeneratedDate { get; set; }

        public long RoomId { get; set; }

    }
}
