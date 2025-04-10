using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Core.Entities.Guest;

[Table("Statuses", Schema = "CSI")]
[Index(nameof(StatusName))] // Improves filtering by status
public class Status : AbstractEntity
{
    [StringLength(100)]
    public string? StatusName { get; set; }

    public virtual List<Guests> GuestsStatuses { get; set; } = new(); // Optimized for ORM
}