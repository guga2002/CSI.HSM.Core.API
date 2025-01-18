using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Advertisments;
using GuestSide.Core.Entities.Language;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Advertisements
{
    [Table("Advertisements", Schema = "CSI")]
    public class Advertisements:AbstractEntity
    {
        public required string Title { get; set; }

        public string? Description {  get; set; }

        [ForeignKey(nameof(AdvertisementType))]
        public long AdvertisementTypeId { get; set; }

        public AdvertisementType AdvertisementType { get; set;}

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set;}

        [ForeignKey(nameof(languagePack))]
        public long LanguageId { get; set; }

        public  LanguagePack languagePack { get; set; }

        public List<byte[]> Pictures { get; set; }
    }
}
