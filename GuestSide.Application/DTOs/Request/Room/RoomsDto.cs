namespace Core.Application.DTOs.Request.Room
{
    public class RoomsDto
    {
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public bool IsAvailable { get; set; } = true;
        public List<string>? Pictures { get; set; }
        public long RoomCategoryId { get; set; }
        public long HotelId { get; set; }
        public long LanguageId { get; set; }
    }
}
