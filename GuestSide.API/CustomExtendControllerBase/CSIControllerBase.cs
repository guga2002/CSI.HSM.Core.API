using GuestSide.API.Response;
using GuestSide.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GuestSide.Core.Entities.Advertisements;

namespace GuestSide.API.CustomExtendControllerBase
{
    /// <summary>
    /// Base controller for handling common CRUD operations for models.
    /// </summary>
    /// <typeparam name="TModel">The model type</typeparam>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TDatabase">The database context type</typeparam>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CSIControllerBase<TModel, TKey, TDatabase> : ControllerBase where TModel : class
    {
        private readonly IService<TModel, TKey, TDatabase> _serviceProvider;

        public CSIControllerBase(IService<TModel, TKey, TDatabase> serviceProvider)
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
        public virtual async Task<Response<IEnumerable<TModel>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await _serviceProvider.GetAllAsync(cancellationToken);
            if (result != null && result.Any())
            {
                return Response<IEnumerable<TModel>>.SuccessResponse(result);
            }
            return Response<IEnumerable<TModel>>.ErrorResponse("No records found.");
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
        public virtual async Task<Response<TModel>> GetByIdAsync([FromRoute] TKey id, CancellationToken cancellationToken = default)
        {
            var result = await _serviceProvider.GetByIdAsync(id, cancellationToken);
            if (result != null)
            {
                return Response<TModel>.SuccessResponse(result);
            }
            return Response<TModel>.ErrorResponse("Record not found.", 404);
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
        public virtual async Task<Response<TModel>> CreateAsync([FromBody] TModel entityDto, CancellationToken cancellationToken = default)
        {
            GuestSide.API.Extensions.ControllerBaseExtension.ValidateModel(this);

            if (entityDto == null)
            {
                return Response<TModel>.ErrorResponse("Invalid input data.", 400);
            }

            var isCreated = await _serviceProvider.CreateAsync(entityDto, cancellationToken);
            if (isCreated)
            {
                return Response<TModel>.SuccessResponse(entityDto, "Record created successfully.");
            }
            return Response<TModel>.ErrorResponse("Failed to create the record.");
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
        public virtual async Task<Response<TModel>> UpdateAsync([FromRoute] TKey id, [FromBody] TModel entityDto, CancellationToken cancellationToken = default)
        {
            if (entityDto == null)
            {
                return Response<TModel>.ErrorResponse("Invalid input data.", 400);
            }

            var isUpdated = await _serviceProvider.UpdateAsync(id, entityDto, cancellationToken);
            if (isUpdated)
            {
                return Response<TModel>.SuccessResponse(entityDto, "Record updated successfully.");
            }
            return Response<TModel>.ErrorResponse("Failed to update the record.");
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
        public virtual async Task<Response<bool>> DeleteAsync([FromRoute] TKey id, CancellationToken cancellationToken = default)
        {
            var isDeleted = await _serviceProvider.DeleteAsync(id, cancellationToken);
            if (isDeleted)
            {
                return Response<bool>.SuccessResponse(true, "Record deleted successfully.");
            }
            return Response<bool>.ErrorResponse("Failed to delete the record or record not found.", 404);
        }

    }

   
}
