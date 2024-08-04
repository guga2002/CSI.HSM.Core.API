using GuestSide.Core.Entities.LogEntities;
using GuestSide.Core.Interfaces.LogInterfaces;
using GuestSide.Infrastructure.Repositories.AbstractRepository;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Infrastructure.Repositories.LogRepo
{
    public class LogRepository : GenericRepository<Logs>, ILogRepository
    {
        public LogRepository(DbContext context) : base(context)
        {
        }
    }
}
