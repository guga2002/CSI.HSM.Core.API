using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Item;
using Domain.Core.Entities.Item;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Item;

[Route("api/[controller]")]
[ApiController]
public class ItemController : CSIControllerBase<ItemDto, ItemResponseDto, long, Items>
{
    private readonly IItemService _itemService;

    public ItemController(
        IService<ItemDto, ItemResponseDto, long, Items> serviceProvider,
        IAdditionalFeatures<ItemDto, ItemResponseDto, long, Items> additionalFeatures,
        IItemService itemService)
        : base(serviceProvider, additionalFeatures)
    {
        _itemService = itemService;
    }

    [HttpGet("category/{categoryId:long}")]
    [SwaggerOperation(Summary = "Retrieve Items by Category", Description = "Returns items filtered by category.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<ItemResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public async Task<Response<IEnumerable<ItemResponseDto>>> GetItemsByCategory(long categoryId)
    {
        var items = await _itemService.GetItemsByCategoryAsync(categoryId);
        return items.Any() ? Response<IEnumerable<ItemResponseDto>>.SuccessResponse(items) : Response<IEnumerable<ItemResponseDto>>.ErrorResponse("No items found for this category.");
    }

    [HttpGet("language/{languageCode}")]
    [SwaggerOperation(Summary = "Retrieve Items by Language", Description = "Returns items filtered by language.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<ItemResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public async Task<Response<IEnumerable<ItemResponseDto>>> GetItemsByLanguage(string languageCode)
    {
        var items = await _itemService.GetItemsByLanguageAsync(languageCode);
        return items.Any() ? Response<IEnumerable<ItemResponseDto>>.SuccessResponse(items) : Response<IEnumerable<ItemResponseDto>>.ErrorResponse("No items found for this language.");
    }

    [HttpGet("orderable")]
    [SwaggerOperation(Summary = "Retrieve Orderable Items", Description = "Returns all orderable items.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<ItemResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public async Task<Response<IEnumerable<ItemResponseDto>>> GetOrderableItems()
    {
        var items = await _itemService.GetOrderableItemsAsync();
        return items.Any() ? Response<IEnumerable<ItemResponseDto>>.SuccessResponse(items) : Response<IEnumerable<ItemResponseDto>>.ErrorResponse("No orderable items found.");
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Items", Description = "Returns all item records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<ItemResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<ItemResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve an Item by ID", Description = "Fetches a specific item record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<ItemResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<ItemResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Item", Description = "Adds a new item record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<ItemResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<ItemResponseDto>> CreateAsync([FromBody] ItemDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing Item", Description = "Updates an existing item record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<ItemResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<ItemResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] ItemDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete an Item", Description = "Deletes an item record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<ItemResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<ItemResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete Items", Description = "Deletes multiple item records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<ItemDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update Items", Description = "Updates multiple item records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<ItemDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add Items", Description = "Adds multiple item records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<ItemDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete an Item", Description = "Marks an item record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<ItemResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<ItemResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
