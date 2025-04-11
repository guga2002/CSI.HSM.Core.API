using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Core.Entities.AbstractEntities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Core.Entities.Language;

[Table("LanguagePacks", Schema = "CSI")]
[Index(nameof(Code))]
[Index(nameof(Name))]
public class LanguagePack : AbstractEntity
{
    [StringLength(10)]
    public required string Code { get; set; }

    [StringLength(100)]
    public required string Name { get; set; }

    public byte[]? LanguageCountryImage { get; set; }
}