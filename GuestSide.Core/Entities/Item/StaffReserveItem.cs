﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Core.Entities.Item;

[Table("StaffReserveItems", Schema = "CSI")]
[Index(nameof(FinalUsed))]
[Index(nameof(ReservedTill))]
public class StaffReserveItem : AbstractEntity //ar viyenebt am cxrils am etapze
{
    public int Quantity { get; set; }

    public bool FinalUsed { get; set; } = false; // Indicates if the reservation was used

    public DateTime ReservationDate { get; set; } = DateTime.UtcNow; // Default reservation timestamp

    public DateTime ReservedTill { get; set; } // Specifies expiration date of reservation

    public DateTime? RequiredDate { get; set; } // When the item is actually needed

    public DateTime? ReturnDate { get; set; } // When the item is returned

    [NotMapped]
    public bool IsExpired => DateTime.UtcNow > ReservedTill && !FinalUsed; // Automatically calculated field

    public bool ReleasedBySystem { get; set; } = false;

    public DateTime? HandledDate { get; set; } // Stores when the reservation was finalized

    [StringLength(300)]
    public string? Notes { get; set; }
}
