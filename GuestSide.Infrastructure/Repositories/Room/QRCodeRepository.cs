using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Persistance.Cashing;
using Domain.Core.Data;
using Domain.Core.Entities.Room;
using Domain.Core.Interfaces.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Core.Infrastructure.Repositories.Room
{
    public class QRCodeRepository : GenericRepository<QRCode>, IQRCodeRepository
    {
        public QRCodeRepository(CoreSideDb context, IRedisCash redisCache, IHttpContextAccessor httpContextAccessor, ILogger<QRCode> logger)
            : base(context, redisCache, httpContextAccessor, logger)
        {
        }

        #region Get QR Code by Room ID
        public async Task<QRCode?> GetQRCodeByRoomId(long roomId)
        {
            return await DbSet
                .Where(qr => qr.RoomId == roomId)
                .FirstOrDefaultAsync();
        }
        #endregion

        #region Get QR Code by Code
        public async Task<QRCode?> GetQRCodeByCode(string qrCode)
        {
            return await DbSet
                .Where(qr => qr.Code == qrCode)
                .FirstOrDefaultAsync();
        }
        #endregion

        #region Increment Scan Count
        public async Task<bool> IncrementScanCount(long qrId)
        {
            var qrCode = await DbSet.FindAsync(qrId);
            if (qrCode == null) return false;

            qrCode.ScannedCount++;
            qrCode.UpdatedAt = DateTime.UtcNow;
            await Context.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Mark QR Code as Expired
        public async Task<bool> MarkQRCodeAsExpired(long qrId)
        {
            var qrCode = await DbSet.FindAsync(qrId);
            if (qrCode == null) return false;

            qrCode.ExpirationDate = DateTime.UtcNow;
            qrCode.UpdatedAt = DateTime.UtcNow;
            await Context.SaveChangesAsync();

            return true;
        }
        #endregion

        #region Get Active QR Codes
        public async Task<IEnumerable<QRCode>> GetActiveQRCodes()
        {
            return await DbSet
                .Where(qr => qr.ExpirationDate == null || qr.ExpirationDate > DateTime.UtcNow)
                .OrderByDescending(qr => qr.CreatedAt)
                .ToListAsync();
        }
        #endregion
    }
}
