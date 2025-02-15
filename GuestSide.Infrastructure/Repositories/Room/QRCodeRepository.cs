using Core.Core.Data;
using Core.Core.Entities.Room;
using Core.Core.Interfaces.Room;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Room
{
    public class QRCodeRepository : GenericRepository<QRCode>, IQRCodeRepository
    {
        public QRCodeRepository(GuestSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<QRCode> logger) : base(context, redisCache, httpContextAccessor, logger)
        {
        }
    }
}
