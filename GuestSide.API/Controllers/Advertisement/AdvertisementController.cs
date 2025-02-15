﻿using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;
using Core.Application.Interface.GenericContracts;
using Core.Core.Data;
using Core.Core.Entities.Advertisements;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Advertisement;

[ApiController]
[Route("api/[controller]")]
public class AdvertisementController : CSIControllerBase<AdvertismentDto, AdvertismentResponseDto, long, Advertisements>
{
    public AdvertisementController(IService<AdvertismentDto, AdvertismentResponseDto, long, Advertisements> serviceProvider, GuestSideDb db, IAdditionalFeatures<AdvertismentDto, AdvertismentResponseDto, long, Advertisements> feat) : base(serviceProvider, feat)
    {
    }

    /// <summary>
    /// Get All Advertisements
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all records", Description = "Returns all records of the specified type.")]
    [ProducesResponseType(typeof(Response<IEnumerable<AdvertismentResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
    public override async Task<Response<IEnumerable<AdvertismentResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a record by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the record.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The record matching the specified ID.</returns>
    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "Retrieve a record by ID", Description = "Fetches a specific record using its unique identifier.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<AdvertismentResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<AdvertismentResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    /// <summary>
    /// Creates a new record.
    /// </summary>
    /// <param name="entityDto">The data for the new record.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The created record.</returns>
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new record", Description = "Adds a new record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<AdvertismentResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<AdvertismentResponseDto>> CreateAsync([FromBody] AdvertismentDto entityDto, CancellationToken cancellationToken = default)
    {
        return await CreateAsync(entityDto, cancellationToken);
    }

    /// <summary>
    /// Updates an existing record.
    /// </summary>
    /// <param name="id">The ID of the record to update.</param>
    /// <param name="entityDto">The updated data for the record.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The updated record.</returns>
    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "Update an existing record", Description = "Modifies the data of an existing record using its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<AdvertismentResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<AdvertismentResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] AdvertismentDto entityDto, CancellationToken cancellationToken = default)
    {
        return await UpdateAsync(id, entityDto, cancellationToken);
    }

    /// <summary>
    /// Deletes a record by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the record to delete.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A success or failure response.</returns>
    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "Delete a record", Description = "Removes a record from the system using its unique identifier.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<AdvertismentResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<AdvertismentResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await DeleteAsync(id, cancellationToken);
    }

    /// <summary>
    /// Deletes multiple entities in bulk.
    /// </summary>
    /// <param name="entities">The collection of entities to delete.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A success or failure response for bulk deletion.</returns>
    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete records", Description = "Deletes multiple records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<AdvertismentDto> entities, CancellationToken cancellationToken = default)
    {
        return await BulkDeleteAsync(entities, cancellationToken);
    }

    /// <summary>
    /// Updates multiple entities in bulk.
    /// </summary>
    /// <param name="entities">The collection of entities to update.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A success or failure response for bulk update.</returns>
    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update records", Description = "Updates multiple records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<AdvertismentDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    /// <summary>
    /// Adds multiple entities in bulk.
    /// </summary>
    /// <param name="entities">The collection of entities to add.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A success or failure response for bulk add.</returns>
    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add records", Description = "Adds multiple records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<AdvertismentDto> entities, CancellationToken cancellationToken = default)
    {
        return await BulkAddAsync(entities, cancellationToken);
    }

    /// <summary>
    /// Performs a soft delete on a record by marking it as deleted without removing it from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the record to soft delete.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A success or failure response for soft deletion.</returns>
    [HttpPatch("soft-delete/{id:int}")]
    [SwaggerOperation(Summary = "Soft delete a record", Description = "Marks a record as deleted without removing it from the database.")]
    [ProducesResponseType(typeof(Response<AdvertismentResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
    public override async Task<Response<AdvertismentResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await SoftDeleteAsync(id, cancellationToken);
    }
}
