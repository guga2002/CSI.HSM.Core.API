using System.ComponentModel.DataAnnotations;

namespace GuestSide.Application.DTOs.Response.Advertisment
{
    public class AdvertismentResponseDto
    {
        public long Id { get; set; }
        public required string Title { get; set; }

        public string? Description { get; set; }

        public long AdvertisementTypeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public required string MediaUrl { get; set; }
    }
}
