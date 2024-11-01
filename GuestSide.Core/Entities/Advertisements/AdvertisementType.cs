using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Advertisements;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Advertisments
{
    [Table("AdvertisementTypes", Schema = "CSI")]
    public class AdvertisementType:AbstractEntity
    {
        public required string Name { get; set; }

        public string? Description {  get; set; }

        public IEnumerable<Advertisements.Advertisements>Advertisements { get; set; }
    }
}
