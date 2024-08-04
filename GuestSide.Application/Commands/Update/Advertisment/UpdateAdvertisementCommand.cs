using System.ComponentModel.DataAnnotations;

namespace GuestSide.Application.Commands.Update.Advertisment
{
    public class UpdateAdvertisementCommand
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public long AdvertisementTypeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public string MediaUrl { get; set; }
    }
}
