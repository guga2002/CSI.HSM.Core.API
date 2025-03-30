using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Room;
using Core.Core.Entities.Room;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Room;

[Route("api/[controller]")]
[ApiController]
public class QrCodeController : CSIControllerBase<QRCodeDto, QRCodeResponseDto, long, QRCode>
{
    private readonly IQrCodeService _qrCodeService;

    public QrCodeController(
        IService<QRCodeDto, QRCodeResponseDto, long, QRCode> serviceProvider,
        IAdditionalFeatures<QRCodeDto, QRCodeResponseDto, long, QRCode> additionalFeatures,
        IQrCodeService qrCodeService)
        : base(serviceProvider, additionalFeatures)
    {
        _qrCodeService = qrCodeService;
    }

    [HttpGet("room/{roomId:long}")]
    [SwaggerOperation(Summary = "Retrieve QR Code by Room ID", Description = "Fetches the QR code associated with a specific room.")]
    [SwaggerResponse(StatusCodes.Status200OK, "QR Code retrieved successfully.", typeof(Response<QRCodeResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "QR Code not found.")]
    public async Task<Response<QRCodeResponseDto>> GetQRCodeByRoomId([FromRoute] long roomId)
    {
        var result = await _qrCodeService.GetQRCodeByRoomId(roomId);
        return result is not null
            ? Response<QRCodeResponseDto>.SuccessResponse(result)
            : Response<QRCodeResponseDto>.ErrorResponse("QR Code not found.");
    }

    [HttpGet("code/{qrCode}")]
    [SwaggerOperation(Summary = "Retrieve QR Code by Code", Description = "Fetches a QR code record using the QR string.")]
    [SwaggerResponse(StatusCodes.Status200OK, "QR Code retrieved successfully.", typeof(Response<QRCodeResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "QR Code not found.")]
    public async Task<Response<QRCodeResponseDto>> GetQRCodeByCode([FromRoute] string qrCode)
    {
        var result = await _qrCodeService.GetQRCodeByCode(qrCode);
        return result is not null
            ? Response<QRCodeResponseDto>.SuccessResponse(result)
            : Response<QRCodeResponseDto>.ErrorResponse("QR Code not found.");
    }

    [HttpPost("increment-scan/{qrId:long}")]
    [SwaggerOperation(Summary = "Increment QR Code Scan Count", Description = "Increments the scan count for a given QR code.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Scan count incremented successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "QR Code not found.")]
    public async Task<Response<bool>> IncrementScanCount([FromRoute] long qrId)
    {
        var result = await _qrCodeService.IncrementScanCount(qrId);
        return result
            ? Response<bool>.SuccessResponse(true, "Scan count updated successfully.")
            : Response<bool>.ErrorResponse("QR Code not found.");
    }

    [HttpPatch("expire/{qrId:long}")]
    [SwaggerOperation(Summary = "Mark QR Code as Expired", Description = "Marks a QR code as expired.")]
    [SwaggerResponse(StatusCodes.Status200OK, "QR Code marked as expired.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "QR Code not found.")]
    public async Task<Response<bool>> MarkQRCodeAsExpired([FromRoute] long qrId)
    {
        var result = await _qrCodeService.MarkQRCodeAsExpired(qrId);
        return result
            ? Response<bool>.SuccessResponse(true, "QR Code marked as expired.")
            : Response<bool>.ErrorResponse("QR Code not found.");
    }

    [HttpGet("active")]
    [SwaggerOperation(Summary = "Retrieve Active QR Codes", Description = "Fetches all active (non-expired) QR codes.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Active QR Codes retrieved successfully.", typeof(Response<IEnumerable<QRCodeResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No active QR Codes found.")]
    public async Task<Response<IEnumerable<QRCodeResponseDto>>> GetActiveQRCodes()
    {
        var result = await _qrCodeService.GetActiveQRCodes();
        return result.Any()
            ? Response<IEnumerable<QRCodeResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<QRCodeResponseDto>>.ErrorResponse("No active QR Codes found.");
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all QR Codes", Description = "Returns all QR code records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<QRCodeResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<QRCodeResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve a QR Code by ID", Description = "Fetches a specific QR code record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<QRCodeResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<QRCodeResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new QR Code", Description = "Adds a new QR code record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<QRCodeResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<QRCodeResponseDto>> CreateAsync([FromBody] QRCodeDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing QR Code", Description = "Updates an existing QR code record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<QRCodeResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<QRCodeResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] QRCodeDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete a QR Code", Description = "Deletes a QR code record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<QRCodeResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<QRCodeResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete QR Codes", Description = "Deletes multiple QR code records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<QRCodeDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update QR Codes", Description = "Updates multiple QR code records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<QRCodeDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add QR Codes", Description = "Adds multiple QR code records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<QRCodeDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete a QR Code", Description = "Marks a QR code record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<QRCodeResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<QRCodeResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
