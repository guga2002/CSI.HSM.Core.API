namespace GuestSide.Application.DTOs.Request.Room
{
    public class RoomsDto
    {
        public int RoomNumber { get; set; }

        public int Floor { get; set; }

        public bool IsAvailable { get; set; } = true;

        public long RoomCategoryId { get; set; }

    }
}
