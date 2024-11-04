namespace GuestSide.Application.DTOs.Response.Room
{
    public class RoomsResponseDto
    {
        public long Id { get; set; }

        public int RoomNumber { get; set; }

        public int Floor { get; set; }

        public bool IsAvailable { get; set; } = true;

        public long RoomCategoryId { get; set; }

    }
}
