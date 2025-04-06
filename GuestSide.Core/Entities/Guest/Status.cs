using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Entities.Guest;

[Table("Statuses", Schema = "CSI")]
[Index(nameof(StatusName))] // Improves filtering by status
[Index(nameof(LanguageCode))] // Optimized for multi-language lookups
public class Status : AbstractEntity
{
    [StringLength(100)]
    public string? StatusName { get; set; }

    [StringLength(10)] // Optimized for storage efficiency
    public string? LanguageCode { get; set; }

    public virtual List<Guests> GuestsStatuses { get; set; } = new(); // Optimized for ORM
}