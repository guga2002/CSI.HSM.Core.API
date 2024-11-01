using GuestSide.Core.Entities.AbstractEntities;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Entities.Task;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestSide.Core.Entities.Item
{
    [Table("Carts", Schema = "CSI")]
    public class Cart:AbstractEntity
    {
        [ForeignKey(nameof(Guest))]
        public long GuestId { get; set; }

        public Guests Guest { get; set; }

        public IEnumerable<Tasks> Tasks {  get; set; }

        public CartToStaff CartToStaff { get; set; }
    }

}
