using Domain.Core.Entities.Room;
using Domain.Core.Interfaces.AbstractInterface;

namespace Domain.Core.Interfaces.Room
{
    public interface IQRCodeRepository : IGenericRepository<QRCode>
    {
        Task<QRCode?> GetQRCodeByRoomId(long roomId);
        Task<QRCode?> GetQRCodeByCode(string qrCode);
        Task<bool> IncrementScanCount(long qrId);
        Task<bool> MarkQRCodeAsExpired(long qrId);
        Task<IEnumerable<QRCode>> GetActiveQRCodes();
    }
}