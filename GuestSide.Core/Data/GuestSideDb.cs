using Microsoft.EntityFrameworkCore;

namespace GuestSide.Core.Data
{
    public class GuestSideDb:DbContext
    {
        public GuestSideDb(DbContextOptions<GuestSideDb> options):base(options)
        {
                
        }
    }
}
