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
public class ItemCategoryController : CSIControllerBase<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory>
{
    private readonly IItemCategoryService _itemCategoryService;

    public ItemCategoryController(
        IItemCategoryService itemCategoryService,
        IService<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory> serviceProvider,
        IAdditionalFeatures<ItemCategoryDto, ItemCategoryResponseDto, long, ItemCategory> additionalFeatures)
        : base(serviceProvider, additionalFeatures)
    {
        _itemCategoryService = itemCategoryService;
    }

    [HttpGet("by-name/{name}")]
    [SwaggerOperation(Summary = "Retrieve category by name", Description = "Fetches a specific item category by its name.")]
    [ProducesResponseType(typeof(Response<ItemCategoryResponseDto>), StatusCodes.Status200OK)]
    public async Task<Response<ItemCategoryResponseDto?>> GetCategoryByName([FromRoute] string name, CancellationToken cancellationToken = default)
    {
        var result = await _itemCategoryService.GetCategoryByNameAsync(name, cancellationToken);
        return new Response<ItemCategoryResponseDto?>(result is not null ? true : false, result);
    }

    [HttpGet("by-language/{languageCode}")]
    [SwaggerOperation(Summary = "Retrieve categories by language", Description = "Fetches all categories available in a specified language.")]
    [ProducesResponseType(typeof(Response<IEnumerable<ItemCategoryResponseDto>>), StatusCodes.Status200OK)]
    public async Task<Response<IEnumerable<ItemCategoryResponseDto>>> GetCategoriesByLanguage([FromRoute] string languageCode, CancellationToken cancellationToken = default)
    {
        var result = await _itemCategoryService.GetCategoriesByLanguageAsync(languageCode, cancellationToken);
        return new Response<IEnumerable<ItemCategoryResponseDto>>(result.Any() ? true : false, result);
    }

    [HttpGet("with-items")]
    [SwaggerOperation(Summary = "Retrieve categories with items", Description = "Fetches all categories that contain items.")]
    [ProducesResponseType(typeof(Response<IEnumerable<ItemCategoryResponseDto>>), StatusCodes.Status200OK)]
    public async Task<Response<IEnumerable<ItemCategoryResponseDto>>> GetCategoriesWithItems(CancellationToken cancellationToken = default)
    {
        var result = await _itemCategoryService.GetCategoriesWithItemsAsync(cancellationToken);
        return new Response<IEnumerable<ItemCategoryResponseDto>>(result.Any() ? true : false, result);
    }

    [HttpPut("update-name/{categoryId:long}")]
    [SwaggerOperation(Summary = "Update category name", Description = "Updates the name of an existing category.")]
    [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
    public async Task<Response<bool>> UpdateCategoryName([FromRoute] long categoryId, [FromBody] string newName, CancellationToken cancellationToken = default)
    {
        var result = await _itemCategoryService.UpdateCategoryNameAsync(categoryId, newName, cancellationToken);
        return new Response<bool>(result ? true : false, result);
    }

    [HttpPut("update-description/{categoryId:long}")]
    [SwaggerOperation(Summary = "Update category description", Description = "Updates the description of an existing category.")]
    [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
    public async Task<Response<bool>> UpdateCategoryDescription([FromRoute] long categoryId, [FromBody] string newDescription, CancellationToken cancellationToken = default)
    {
        var result = await _itemCategoryService.UpdateCategoryDescriptionAsync(categoryId, newDescription, cancellationToken);
        return new Response<bool>(result ? true : false, result);
    }

    [HttpPut("change-language/{categoryId:long}")]
    [SwaggerOperation(Summary = "Change category language", Description = "Changes the language of an existing category.")]
    [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
    public async Task<Response<bool>> ChangeCategoryLanguage([FromRoute] long categoryId, [FromBody] string newLanguageCode, CancellationToken cancellationToken = default)
    {
        var result = await _itemCategoryService.ChangeCategoryLanguageAsync(categoryId, newLanguageCode, cancellationToken);
        return new Response<bool>(result ? true : false, result);
    }

    [HttpGet("count-total")]
    [SwaggerOperation(Summary = "Count total categories", Description = "Returns the total number of categories.")]
    [ProducesResponseType(typeof(Response<int>), StatusCodes.Status200OK)]
    public async Task<Response<int>> CountTotalCategories(CancellationToken cancellationToken = default)
    {
        var result = await _itemCategoryService.CountTotalCategoriesAsync(cancellationToken);
        return new Response<int>(true, result);
    }

    [HttpGet("count-with-items")]
    [SwaggerOperation(Summary = "Count categories with items", Description = "Returns the number of categories that contain items.")]
    [ProducesResponseType(typeof(Response<int>), StatusCodes.Status200OK)]
    public async Task<Response<int>> CountCategoriesWithItems(CancellationToken cancellationToken = default)
    {
        var result = await _itemCategoryService.CountCategoriesWithItemsAsync(cancellationToken);
        return new Response<int>(true, result);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Item Categories", Description = "Returns all item category records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<ItemCategoryResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<ItemCategoryResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve an Item Category by ID", Description = "Fetches a specific item category record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<ItemCategoryResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<ItemCategoryResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Item Category", Description = "Adds a new item category record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<ItemCategoryResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<ItemCategoryResponseDto>> CreateAsync([FromBody] ItemCategoryDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing Item Category", Description = "Updates an existing item category record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<ItemCategoryResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<ItemCategoryResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] ItemCategoryDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete an Item Category", Description = "Deletes an item category record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<ItemCategoryResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
    public override async Task<Response<ItemCategoryResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete Item Categories", Description = "Deletes multiple item category records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<ItemCategoryDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update Item Categories", Description = "Updates multiple item category records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<ItemCategoryDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add Item Categories", Description = "Adds multiple item category records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<ItemCategoryDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete an Item Category", Description = "Marks an item category record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<ItemCategoryResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<ItemCategoryResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
