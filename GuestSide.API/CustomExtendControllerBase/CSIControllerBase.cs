using GuestSide.API.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using Core.Application.Interface.GenericContracts;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace GuestSide.API.CustomExtendControllerBase;

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
    private readonly IAdditionalFeatures<RequestDto, RsponseDto, TKey, TDatabase> _additionalFeatures;
    protected string HotelId => GetHotelId();


    private string GetHotelId()
    {
        if (!HttpContext.Request.Headers.TryGetValue("X-Hotel-Id", out var hotelId) || string.IsNullOrWhiteSpace(hotelId))
        {
            throw new Exception("X-Hotel-Id header is required.");
        }

        return hotelId;
    }

    public CSIControllerBase(IService<RequestDto, RsponseDto, TKey, TDatabase> serviceProvider,
        IAdditionalFeatures<RequestDto, RsponseDto, TKey, TDatabase> additionalFeatures)
    {
        _serviceProvider = serviceProvider;
        _additionalFeatures = additionalFeatures;
    }


    /// <summary>
    /// Retrieves all records.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the request.</param>
    /// <returns>A list of all models.</returns>
    [HttpGet()]
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
    [HttpGet("{id:int}")]
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
    [HttpPost()]
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
    [HttpPut("{id:int}")]
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
    [HttpDelete("{id:int}")]
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

    /// <summary>
    /// Checks if a record exists based on the provided predicate.
    /// </summary>
    /// <param name="predicate">The condition to evaluate the existence of a record.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A response indicating whether the record exists or not.</returns>
    [HttpGet("exist")]
    [SwaggerOperation(
        Summary = "Check if a record exists",
        Description = "Verifies the existence of a record in the database based on the specified predicate."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Record exists", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record does not exist", typeof(Response<bool>))]
    public virtual async Task<Response<bool>> ExistsAsync([FromRoute]Expression<Func<RequestDto, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var result = await _additionalFeatures.ExistsAsync(predicate, cancellationToken);
        return result ? Response<bool>.SuccessResponse(result)
        : Response<bool>.ErrorResponse("Record does not exist");
    }

    /// <summary>
    /// Retrieve paged records
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="orderBy"></param>
    /// <param name="isAscending"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("Paged/{pageNumber:int}/{pageSize:int}")]
    [SwaggerOperation(
        Summary = "Retrieve paged records",
        Description = "Fetches a paginated list of records filtered by a condition, sorted by a specified field, and includes the total record count."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Paged records retrieved successfully")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found matching the criteria")]
    public virtual async Task<Response<(IEnumerable<RsponseDto>, int)>> GetPagedAsync(
         [FromQuery] Expression<Func<TDatabase, bool>> predicate,
          int pageNumber,
          int pageSize,
         [FromQuery] Expression<Func<TDatabase, object>> orderBy,
        bool isAscending = true,
        CancellationToken cancellationToken = default)
    {
        var res = await _additionalFeatures.GetPagedAsync(predicate, pageNumber, pageSize, orderBy, isAscending, cancellationToken);

        return res.Item1.Any()
            ? Response<(IEnumerable<RsponseDto>, int)>.SuccessResponse(res)
            : Response<(IEnumerable<RsponseDto>, int)>.ErrorResponse("No records found");
    }

    /// <summary>
    /// Deletes multiple entities in bulk based on the provided data.
    /// </summary>
    /// <param name="entities">The collection of entities to delete.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>An asynchronous operation representing the bulk delete process.</returns>
    [HttpDelete("bulk")]
    [SwaggerOperation(
        Summary = "Delete multiple entities in bulk",
        Description = "Deletes a collection of entities in a single operation."
    )]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Entities deleted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data")]
    public virtual async Task<IActionResult> BulkDeleteAsync([FromBody]IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
    {
        GuestSide.API.Extensions.ControllerBaseExtension.ValidateModel(this);

        if (entities == null || !entities.Any())
        {
            return BadRequest("Invalid input data. The collection cannot be empty or null.");
        }

        await _additionalFeatures.BulkDeleteAsync(entities, cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Updates multiple entities in bulk based on the provided data.
    /// </summary>
    /// <param name="entities">The collection of entities to update.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>An IActionResult indicating the result of the operation.</returns>
    [HttpPut("bulk")]
    [SwaggerOperation(
        Summary = "Update multiple entities in bulk",
        Description = "Performs a bulk update operation on a collection of entities."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data")]
    public virtual async Task<IActionResult> BulkUpdateAsync([FromBody]IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
    {
        GuestSide.API.Extensions.ControllerBaseExtension.ValidateModel(this);

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
    /// Adds multiple entities in bulk based on the provided data.
    /// </summary>
    /// <param name="entities">The collection of entities to add.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>An IActionResult indicating the result of the operation.</returns>
    [HttpPost("bulk")]
    [SwaggerOperation(
        Summary = "Add multiple entities in bulk",
        Description = "Performs a bulk insert operation for a collection of entities."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities inserted successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data")]

    public virtual async Task<IActionResult> BulkAddAsync([FromBody]IEnumerable<RequestDto> entities, CancellationToken cancellationToken = default)
    {
        GuestSide.API.Extensions.ControllerBaseExtension.ValidateModel(this);

        if (entities == null || !entities.Any())
        {
            return BadRequest("Invalid input data. The collection cannot be empty or null.");
        }

        await _additionalFeatures.BulkAddAsync(entities, cancellationToken);

        return Ok(new
        {
            Message = "Entities inserted successfully",
            InsertedCount = entities.Count()
        });
    }

    /// <summary>
    /// Executes a raw SQL query and returns the results as a collection of DTOs.
    /// </summary>
    /// <typeparam name="TResult">The type of the result expected from the query.</typeparam>
    /// <param name="query">The raw SQL query to execute.</param>
    /// <param name="parameters">The parameters to be passed to the SQL query.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A response containing the result set as a collection of DTOs or an error message.</returns>
    [HttpPost(nameof(ExecuteRawSql))]
    [SwaggerOperation(
        Summary = "Execute a raw SQL query",
        Description = "Executes a raw SQL query and retrieves results as a collection of DTOs."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Query executed successfully")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data, such as an empty or null query")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No data found for the given query")]
    public virtual async Task<Response<IEnumerable<RsponseDto>>> ExecuteRawSql<TResult>(
        [FromQuery]string query,
        [FromQuery]object[] parameters,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return Response<IEnumerable<RsponseDto>>.ErrorResponse("Invalid input data. The query cannot be empty or null.");
        }

        var result = await _additionalFeatures.ExecuteRawSql<RsponseDto>(query, parameters, cancellationToken);

        return result != null && result.Any()
            ? Response<IEnumerable<RsponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<RsponseDto>>.ErrorResponse("No data found for the given query.");
    }

    /// <summary>
    /// Soft deletes a record identified by the specified ID.
    /// </summary>
    /// <param name="id">The unique identifier of the record to soft delete.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A response containing the details of the deleted record or an error message if the record was not found.</returns>
    [HttpGet(nameof(SoftDelete))]
    [SwaggerOperation(
        Summary = "Soft delete a record by ID",
        Description = "Marks a record as deleted without removing it from the database, based on the provided ID."
    )]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found")]
    public virtual async Task<Response<RsponseDto>> SoftDelete(
        [FromQuery]TKey id,
        CancellationToken cancellationToken = default)
    {
        var res = await _additionalFeatures.SoftDelete(id, cancellationToken);

        return res != null
            ? Response<RsponseDto>.SuccessResponse(res)
            : Response<RsponseDto>.ErrorResponse("Record not found.");
    }
}
