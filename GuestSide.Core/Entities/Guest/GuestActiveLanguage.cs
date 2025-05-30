﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Guest;

[Table("GuestLanguages", Schema = "CSI")]
public class GuestActiveLanguage : AbstractEntity
{
    [ForeignKey(nameof(Guest))]
    public long GuestId { get; set; }

    public DateTime SetDate { get; set; } = DateTime.UtcNow;

    public virtual Guests? Guest { get; set; }
}