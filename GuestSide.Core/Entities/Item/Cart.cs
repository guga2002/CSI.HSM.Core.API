using Core.Core.Entities.AbstractEntities;
using Core.Core.Entities.Guest;
using Core.Core.Entities.Language;
using Core.Core.Entities.Task;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Core.Entities.Item;

[Table("Carts", Schema = "CSI")]
[Index(nameof(LanguageId))]
public class Cart : AbstractEntity
{
    [ForeignKey(nameof(guest))]
    public long GuestId { get; set; }

    [StringLength(100)]
    public string? WhatWillRobotSay { get; set; }

    public virtual Guests? guest { get; set; }

    public virtual IEnumerable<Tasks> Tasks { get; set; }

    [ForeignKey(nameof(language))]
    public long LanguageId { get; set; }

    public virtual LanguagePack? language { get; set; }

    public bool IsComplete { get; set; }

    public decimal SubTotal => Tasks?.Sum(x => x.Total) ?? 0;

    public Cart(string PatternWhatWillwobotSay = "HI {0}, you inicialize card,  happy  shopping")
    {
        WhatWillRobotSay = string.Format(PatternWhatWillwobotSay, guest?.FirstName + " " + guest?.LastName);
    }

    public Cart()
    {

    }

}
