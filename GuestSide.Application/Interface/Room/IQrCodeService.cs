using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Room;

namespace Core.Application.Interface.Room
{
    public interface IQrCodeService : IService<QRCodeDto, QRCodeResponseDto, long, QRCode>,
        IAdditionalFeatures<QRCodeDto, QRCodeResponseDto, long, QRCode>
    {
        /// <summary>
        /// Get QR code details by Room ID.
        /// </summary>
        Task<QRCodeResponseDto?> GetQRCodeByRoomId(long roomId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get QR code details by QR string.
        /// </summary>
        Task<QRCodeResponseDto?> GetQRCodeByCode(string qrCode, CancellationToken cancellationToken = default);

        /// <summary>
        /// Increment scan count for a QR code.
        /// </summary>
        Task<bool> IncrementScanCount(long qrId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Mark a QR code as expired.
        /// </summary>
        Task<bool> MarkQRCodeAsExpired(long qrId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all active (non-expired) QR codes.
        /// </summary>
        Task<IEnumerable<QRCodeResponseDto>> GetActiveQRCodes(CancellationToken cancellationToken = default);
    }
}