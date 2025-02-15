using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Guest;

[Table("GuestLanguages", Schema = "CSI")]
public class GuestActiveLanguage : AbstractEntity
{
    [ForeignKey("Guest")]
    public long GuestId { get; set; }
    [StringLength(100)]
    public string? LanguageCode { get; set; }
    public DateTime SetDate { get; set; }
    public Guests Guest { get; set; }
}
