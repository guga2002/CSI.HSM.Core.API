using GuestSide.API.Response;
using GuestSide.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.CustomExtendControllerBase
{
    /// <summary>
    /// Base controller for handling common CRUD operations for models.
    /// </summary>
    /// <typeparam name="RequestDto"></typeparam>
    /// <typeparam name="RsponseDto"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TDatabase"></typeparam>
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [AllowAnonymous]
    public class CSIControllerBase<RequestDto,RsponseDto, TKey, TDatabase> : ControllerBase
            where RequestDto : class
            where RsponseDto : class
    {
        private readonly IService<RequestDto, RsponseDto, TKey, TDatabase> _serviceProvider;
        protected string HotelId => GetHotelId();

        private string GetHotelId()
        {
            if (!HttpContext.Request.Headers.TryGetValue("X-Hotel-Id", out var hotelId) || string.IsNullOrWhiteSpace(hotelId))
            {
                throw new Exception("X-Hotel-Id header is required.");
            }

            return hotelId;
        }

        public CSIControllerBase(IService<RequestDto, RsponseDto, TKey, TDatabase> serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Retrieves all records.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all models.</returns>
        [HttpGet("GetAll")]
        [SwaggerOperation(Summary = "Retrieve all records", Description = "Returns all the records of type TModel.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public virtual async Task<Response<IEnumerable<RsponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _serviceProvider.GetAllAsync(cancellationToken);
            if (result is not null && result.Any())
            {
                return Response<IEnumerable<RsponseDto>>.SuccessResponse(result);
            }
            return Response<IEnumerable<RsponseDto>>.ErrorResponse("No records found.");
        }

        /// <summary>
        /// Retrieves a record by its ID.
        /// </summary>
        /// <param name="id">The record ID.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The record matching the specified ID.</returns>
        [HttpGet("GetById/{id}")]
        [SwaggerOperation(Summary = "Retrieve a record by ID", Description = "Returns a specific record by its ID.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public virtual async Task<Response<RsponseDto>> GetByIdAsync([FromRoute] TKey id, CancellationToken cancellationToken = default)
        {
            var result = await _serviceProvider.GetByIdAsync(id, cancellationToken);
            if (result is not null)
            {
                return Response<RsponseDto>.SuccessResponse(result);
            }
            return Response<RsponseDto>.ErrorResponse("Record not found.", 404);
        }

        /// <summary>
        /// Creates a new record.
        /// </summary>
        /// <param name="entityDto">The entity to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created record.</returns>
        [HttpPost("Create")]
        [SwaggerOperation(Summary = "Create a new record", Description = "Creates a new record of type TModel.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public virtual async Task<Response<RsponseDto>> CreateAsync([FromBody] RequestDto entityDto, CancellationToken cancellationToken = default)
        {
            GuestSide.API.Extensions.ControllerBaseExtension.ValidateModel(this);

            if (entityDto == null)
            {
                return Response<RsponseDto>.ErrorResponse("Invalid input data.", 400);
            }

            var createdObject = await _serviceProvider.CreateAsync(entityDto, cancellationToken);
            if (createdObject is not null)
            {
                return Response<RsponseDto>.SuccessResponse(createdObject, "Record created successfully.");
            }
            return Response<RsponseDto>.ErrorResponse("Failed to create the record.");
        }

        /// <summary>
        /// Updates an existing record.
        /// </summary>
        /// <param name="id">The ID of the record to update.</param>
        /// <param name="entityDto">The updated entity data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated record.</returns>
        [HttpPut("Update/{id}")]
        [SwaggerOperation(Summary = "Update an existing record", Description = "Updates the record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public virtual async Task<Response<RsponseDto>> UpdateAsync([FromRoute] TKey id, [FromBody] RequestDto entityDto, CancellationToken cancellationToken = default)
        {
            if (entityDto == null)
            {
                return Response<RsponseDto>.ErrorResponse("Invalid input data.", 400);
            }

            var updateItem = await _serviceProvider.UpdateAsync(id, entityDto, cancellationToken);
            if (updateItem is not null)
            {
                return Response<RsponseDto>.SuccessResponse(updateItem, "Record updated successfully.");
            }
            return Response<RsponseDto>.ErrorResponse("Failed to update the record.");
        }

        /// <summary>
        /// Deletes a record by its ID.
        /// </summary>
        /// <param name="id">The ID of the record to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("Delete/{id}")]
        [SwaggerOperation(Summary = "Delete a record", Description = "Deletes the record with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
        public virtual async Task<Response<RsponseDto>> DeleteAsync([FromRoute] TKey id, CancellationToken cancellationToken = default)
        {
            var deleteItem = await _serviceProvider.DeleteAsync(id, cancellationToken);
            if (deleteItem is not null)
            {
                return Response<RsponseDto>.SuccessResponse(deleteItem, "Record deleted successfully.");
            }
            return Response<RsponseDto>.ErrorResponse("Failed to delete the record or record not found.", 404);
        }
    }
}
