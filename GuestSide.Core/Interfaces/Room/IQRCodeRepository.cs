using Core.Core.Entities.Room;
using Core.Core.Interfaces.AbstractInterface;

namespace Core.Core.Interfaces.Room
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