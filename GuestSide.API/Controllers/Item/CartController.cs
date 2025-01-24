using Core.Application.Interface.GenericContracts;
using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Core.Entities.Item;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Item;

[Route("api/[controller]")]
[ApiController]
public class CartController : CSIControllerBase<CartDto, CartResponseDto, long, Cart>
{
    public CartController(
        IService<CartDto, CartResponseDto, long, Cart> serviceProvider,
        IAdditionalFeatures<CartDto, CartResponseDto, long, Cart> additionalFeatures)
        : base(serviceProvider, additionalFeatures)
    {
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Cart records", Description = "Returns all cart records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<CartResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<CartResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve a Cart by ID", Description = "Fetches a specific cart record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<CartResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<CartResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Cart record", Description = "Adds a new cart record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<CartResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<CartResponseDto>> CreateAsync([FromBody] CartDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing Cart record", Description = "Updates an existing cart record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<CartResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<CartResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] CartDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete a Cart record", Description = "Deletes a cart record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<CartResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<CartResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete Cart records", Description = "Deletes multiple cart records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<CartDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update Cart records", Description = "Updates multiple cart records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<CartDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add Cart records", Description = "Adds multiple cart records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<CartDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete a Cart record", Description = "Marks a cart record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<CartResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<CartResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
