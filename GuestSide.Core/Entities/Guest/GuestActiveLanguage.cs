using Core.Core.Entities.AbstractEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Guest;

[Table("GuestLanguages", Schema = "CSI")]
[Index(nameof(GuestId))] 
[Index(nameof(LanguageCode))] 
[Index(nameof(SetDate))] 
public class GuestActiveLanguage : AbstractEntity
{
    [ForeignKey(nameof(Guest))]
    public long GuestId { get; set; }

    [StringLength(10)] 
    public string? LanguageCode { get; set; }

    public DateTime SetDate { get; set; } = DateTime.UtcNow; 

    public virtual Guests Guest { get; set; } 
}