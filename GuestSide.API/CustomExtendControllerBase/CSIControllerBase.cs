using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using Core.Application.Interface.GenericContracts;
using MongoDB.Driver;
using Core.API.Extensions;
using Core.API.Response;

namespace Core.API.CustomExtendControllerBase;

/// <summary>
/// Base controller for handling common CRUD operations for models.
/// </summary>
/// <typeparam name="RequestDto">The DTO type for incoming requests.</typeparam>
/// <typeparam name="RsponseDto">The DTO type for responses.</typeparam>
/// <typeparam name="TKey">The type of the entity identifier.</typeparam>
/// <typeparam name="TDatabase">The type of the database context.</typeparam>
[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class CSIControllerBase<RequestDto, RsponseDto, TKey, TDatabase> : ControllerBase
    where RequestDto : class
    where RsponseDto : class
{
    private readonly IService<RequestDto, RsponseDto, TKey, TDatabase> _serviceProvider;
    private readonly IAdditionalFeatures<RequestDto, RsponseDto, TKey, TDatabase> _additionalFeatures;

    /// <summary>
    /// Gets the Hotel ID from the request headers.
    /// </summary>
    protected string HotelId => GetHotelId();

    private string GetHotelId()
    {
        if (!HttpContext.Request.Headers.TryGetValue("X-Hotel-Id", out var hotelId) || string.IsNullOrWhiteSpace(hotelId))
        {
            throw new Exception("X-Hotel-Id header is required.");
        }

        return hotelId;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CSIControllerBase{RequestDto, RsponseDto, TKey, TDatabase}"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider for CRUD operations.</param>
    /// <param name="additionalFeatures">Additional features service for bulk operations.</param>
    public CSIControllerBase(IService<RequestDto, RsponseDto, TKey, TDatabase> serviceProvider,
        IAdditionalFeatures<RequestDto, RsponseDto, TKey, TDatabase> additionalFeatures)
    {
        _serviceProvider = serviceProvider;
        _additionalFeatures = additionalFeatures;
    }

    /// <summary>
    /// Retrieves all records.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A list of all records.</returns>
    [HttpGet]
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
    /// <param name="id">The unique identifier of the record.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The record matching the specified ID.</returns>
    [HttpGet("{id:int}")]
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
    /// <param name="entityDto">The data for the new record.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The created record.</returns>
    [HttpPost]
    public virtual async Task<Response<RsponseDto>> CreateAsync([FromBody] RequestDto entityDto, CancellationToken cancellationToken = default)
    {
        this.ValidateModel();

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
    /// <param name="entityDto">The updated data for the record.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>The updated record.</returns>
    [HttpPut("{id:int}")]
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
    /// <param name="id">The unique identifier of the record to delete.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A success or failure response.</returns>
    [HttpDelete("{id:int}")]
    public virtual async Task<Response<RsponseDto>> DeleteAsync([FromRoute] TKey id, CancellationToken cancellationToken = default)
    {
        var deleteItem = await _serviceProvider.DeleteAsync(id, cancellationToken);
        if (deleteItem is not null)
        {
            return Response<RsponseDto>.SuccessResponse(deleteItem, "Record deleted successfully.");
        }
        return Response<RsponseDto>.ErrorResponse("Failed to delete the record or record not found.", 404);
    }

    /// <summary>
    /// Deletes multiple entities in bulk.
    /// </summary>
    /// <param name="entities">The collection of entities to delete.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A success or failure response for bulk deletion.</returns>
    [HttpDelete("bulk")]
    public virtual async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
    {
        this.ValidateModel();

        if (entities == null || !entities.Any())
        {
            return BadRequest("Invalid input data. The collection cannot be empty or null.");
        }

        await _additionalFeatures.BulkDeleteAsync(entities, cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Updates multiple entities in bulk.
    /// </summary>
    /// <param name="entities">The collection of entities to update.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A success or failure response for bulk update.</returns>
    [HttpPut("bulk")]
    public virtual async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
    {
        this.ValidateModel();

        if (entities == null || !entities.Any())
        {
            return BadRequest("Invalid input data. The collection cannot be empty or null.");
        }

        await _additionalFeatures.BulkUpdateAsync(entities, cancellationToken);

        return Ok(new
        {
            Message = "Entities updated successfully",
            UpdatedCount = entities.Count()
        });
    }

    /// <summary>
    /// Adds multiple entities in bulk.
    /// </summary>
    /// <param name="entities">The collection of entities to add.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A success or failure response for bulk add.</returns>
    [HttpPost("bulk")]
    public virtual async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
    {
        this.ValidateModel();

        if (entities == null || !entities.Any())
        {
            return BadRequest("Invalid input data. The collection cannot be empty or null.");
        }

        await _additionalFeatures.BulkAddAsync(entities, cancellationToken);

        return Ok(new
        {
            Message = "Entities added successfully",
            AddedCount = entities.Count()
        });
    }

    /// <summary>
    /// Performs a soft delete on a record by marking it as deleted without removing it from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the record to soft delete.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A success or failure response for soft deletion.</returns>
    [HttpPatch("soft-delete/{id:int}")]
    public virtual async Task<Response<RsponseDto>> SoftDeleteAsync([FromRoute] TKey id, CancellationToken cancellationToken = default)
    {
        var result = await _additionalFeatures.SoftDelete(id, cancellationToken);
        return result != null
            ? Response<RsponseDto>.SuccessResponse(result, "Record soft deleted successfully.")
            : Response<RsponseDto>.ErrorResponse("Record not found.");
    }
}
