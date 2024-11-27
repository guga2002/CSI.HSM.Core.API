namespace GuestSide.Application.DTOs.Response.Hotel
{
    public class HotelResponse
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int Stars { get; set; }

        public string? Description { get; set; }
    }
}
