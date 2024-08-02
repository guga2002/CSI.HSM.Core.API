using System.ComponentModel.DataAnnotations.Schema;
using GuestSide.Core.Entities.AbstractEntities;

namespace GuestSide.Core.Entities.Staff
{
    [Table("StaffCategories")]
    public class StaffCategory:AbstractEntity
    {
        public required string CategoryName { get; set; }
        public IEnumerable<Staffs>Staff { get; set; }
    }
}
