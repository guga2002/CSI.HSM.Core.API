using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Room;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Room;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Room
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrCodeController : CSIControllerBase<QRCodeDto, long, QRCode>
    {
        public QrCodeController(IService<QRCodeDto, long, QRCode> service) : base(service) { }

        /// <summary>
        /// Retrieves all QR codes.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all QR codes.</returns>
        [HttpGet("GetAllQRCodes")]
        [SwaggerOperation(Summary = "Retrieve all QR codes", Description = "Returns a list of all QR codes.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved QR codes.", typeof(Response<IEnumerable<QRCodeDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No QR codes found.")]
        public override Task<Response<IEnumerable<QRCodeDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a QR code by its ID.
        /// </summary>
        /// <param name="id">The ID of the QR code.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The QR code matching the specified ID.</returns>
        [HttpGet("GetQRCodeById/{id}")]
        [SwaggerOperation(Summary = "Retrieve QR code by ID", Description = "Returns a specific QR code by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the QR code.", typeof(Response<QRCodeDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "QR code not found.")]
        public override Task<Response<QRCodeDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new QR code.
        /// </summary>
        /// <param name="entityDto">The QR code to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created QR code.</returns>
        [HttpPost("CreateQRCode")]
        [SwaggerOperation(Summary = "Create a new QR code", Description = "Creates a new QR code.")]
        [SwaggerResponse(StatusCodes.Status201Created, "QR code created successfully.", typeof(Response<QRCodeDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<QRCodeDto>> CreateAsync([FromBody] QRCodeDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing QR code.
        /// </summary>
        /// <param name="id">The ID of the QR code to update.</param>
        /// <param name="entityDto">The updated QR code data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated QR code.</returns>
        [HttpPut("UpdateQRCode/{id}")]
        [SwaggerOperation(Summary = "Update an existing QR code", Description = "Updates the QR code with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "QR code updated successfully.", typeof(Response<QRCodeDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override Task<Response<QRCodeDto>> UpdateAsync([FromRoute] long id, [FromBody] QRCodeDto entityDto, CancellationToken cancellationToken = default)
        {
            return base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes a QR code by its ID.
        /// </summary>
        /// <param name="id">The ID of the QR code to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteQRCode/{id}")]
        [SwaggerOperation(Summary = "Delete a QR code", Description = "Deletes the QR code with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "QR code deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "QR code not found or failed to delete.")]
        public override Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
