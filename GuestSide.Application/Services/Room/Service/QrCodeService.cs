using AutoMapper;
using Common.Data.Entities.Room;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Interfaces.Room;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.Room;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Room.Service
{
    public class QrCodeService : GenericService<QRCodeDto, QRCodeResponseDto, long, QRCode>, IQrCodeService
    {
        private readonly IQRCodeRepository _qrCodeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<QrCodeService> _logger;

        public QrCodeService(
            IMapper mapper,
            IQRCodeRepository qrCodeRepository,
            ILogger<QrCodeService> logger,
            IAdditionalFeaturesRepository<QRCode> additionalFeatures)
            : base(mapper, qrCodeRepository, logger, additionalFeatures)
        {
            _qrCodeRepository = qrCodeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        private void ValidatePositiveId(long id, string paramName)
        {
            if (id <= 0)
            {
                _logger.LogWarning("{ParameterName} must be a positive number.", paramName);
                throw new ArgumentException($"{paramName} must be greater than zero.", paramName);
            }
        }

        private void ValidateString(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _logger.LogWarning("{ParameterName} cannot be empty or whitespace.", paramName);
                throw new ArgumentException($"{paramName} cannot be empty or whitespace.", paramName);
            }
        }

        public async Task<QRCodeResponseDto?> GetQRCodeByRoomId(long roomId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(roomId, nameof(roomId));

            var qrCode = await _qrCodeRepository.GetQRCodeByRoomId(roomId);
            return qrCode is null ? null : _mapper.Map<QRCodeResponseDto>(qrCode);
        }

        public async Task<QRCodeResponseDto?> GetQRCodeByCode(string qrCode, CancellationToken cancellationToken = default)
        {
            ValidateString(qrCode, nameof(qrCode));

            var qrEntity = await _qrCodeRepository.GetQRCodeByCode(qrCode);
            return qrEntity is null ? null : _mapper.Map<QRCodeResponseDto>(qrEntity);
        }

        public async Task<bool> IncrementScanCount(long qrId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(qrId, nameof(qrId));

            var qrEntity = await _qrCodeRepository.GetByIdAsync(qrId, cancellationToken);
            if (qrEntity is null)
            {
                _logger.LogWarning("QR code with ID {QRId} does not exist.", qrId);
                throw new ArgumentException($"QR code with ID {qrId} does not exist.");
            }

            if (!qrEntity.IsActive)
            {
                _logger.LogWarning("QR code with ID {QRId} is expired and cannot be scanned.", qrId);
                throw new InvalidOperationException($"QR code with ID {qrId} is expired and cannot be scanned.");
            }

            return await _qrCodeRepository.IncrementScanCount(qrId);
        }

        public async Task<bool> MarkQRCodeAsExpired(long qrId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(qrId, nameof(qrId));

            var qrEntity = await _qrCodeRepository.GetByIdAsync(qrId, cancellationToken);
            if (qrEntity is null)
            {
                _logger.LogWarning("QR code with ID {QRId} does not exist.", qrId);
                throw new ArgumentException($"QR code with ID {qrId} does not exist.");
            }

            if (!qrEntity.IsActive)
            {
                _logger.LogWarning("QR code with ID {QRId} is already expired.", qrId);
                return false; // Already expired
            }

            return await _qrCodeRepository.MarkQRCodeAsExpired(qrId);
        }

        public async Task<IEnumerable<QRCodeResponseDto>> GetActiveQRCodes(CancellationToken cancellationToken = default)
        {
            var qrCodes = await _qrCodeRepository.GetActiveQRCodes();
            return _mapper.Map<IEnumerable<QRCodeResponseDto>>(qrCodes);
        }
    }
}
