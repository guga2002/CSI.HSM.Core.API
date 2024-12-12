using System.ComponentModel.DataAnnotations;

namespace GuestSide.Core.Entities.AbstractEntities
{
    public abstract class AbstractEntity
    {
        [Key]
        public long Id { get; set; }


    }
}
