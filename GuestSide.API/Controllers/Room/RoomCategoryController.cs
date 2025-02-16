using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Room;
using Core.Application.DTOs.Response.Room;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Room;
using Core.Core.Entities.Room;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Room
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomCategoryController : CSIControllerBase<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory>
    {
        private readonly IRoomCategoryService _roomCategoryService;

        public RoomCategoryController(
            IService<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory> serviceProvider,
            IAdditionalFeatures<RoomCategoryDto, RoomCategoryResponseDto, long, RoomCategory> additionalFeatures,
            IRoomCategoryService roomCategoryService)
            : base(serviceProvider, additionalFeatures)
        {
            _roomCategoryService = roomCategoryService;
        }

        [HttpGet("by-name/{categoryName}")]
        [SwaggerOperation(Summary = "Retrieve Room Category by Name", Description = "Fetches the details of a room category by its name.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Category retrieved successfully.", typeof(Response<RoomCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Category not found.")]
        public async Task<Response<RoomCategoryResponseDto>> GetCategoryByName([FromRoute] string categoryName)
        {
            var result = await _roomCategoryService.GetCategoryByName(categoryName);
            return result is not null
                ? Response<RoomCategoryResponseDto>.SuccessResponse(result)
                : Response<RoomCategoryResponseDto>.ErrorResponse("Category not found.");
        }

        [HttpGet("active")]
        [SwaggerOperation(Summary = "Retrieve Active Room Categories", Description = "Fetches all active (non-deleted) room categories.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Active categories retrieved successfully.", typeof(Response<IEnumerable<RoomCategoryResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No active categories found.")]
        public async Task<Response<IEnumerable<RoomCategoryResponseDto>>> GetAllActiveCategories()
        {
            var result = await _roomCategoryService.GetAllActiveCategories();
            return result.Any()
                ? Response<IEnumerable<RoomCategoryResponseDto>>.SuccessResponse(result)
                : Response<IEnumerable<RoomCategoryResponseDto>>.ErrorResponse("No active categories found.");
        }

        [HttpPatch("update-name/{categoryId:long}")]
        [SwaggerOperation(Summary = "Update Room Category Name", Description = "Updates the name of a room category.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Category name updated successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Category not found.")]
        public async Task<Response<bool>> UpdateRoomCategoryName([FromRoute] long categoryId, [FromBody] string newName)
        {
            var result = await _roomCategoryService.UpdateRoomCategoryName(categoryId, newName);
            return result
                ? Response<bool>.SuccessResponse(true, "Category name updated successfully.")
                : Response<bool>.ErrorResponse("Category not found.");
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all Room Categories", Description = "Returns all room category records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<RoomCategoryResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<RoomCategoryResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:long}")]
        [SwaggerOperation(Summary = "Retrieve a Room Category by ID", Description = "Fetches a specific room category record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<RoomCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<RoomCategoryResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Room Category", Description = "Adds a new room category record to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<RoomCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<RoomCategoryResponseDto>> CreateAsync([FromBody] RoomCategoryDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpPut("{id:long}")]
        [SwaggerOperation(Summary = "Update an existing Room Category", Description = "Updates an existing room category record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<RoomCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<RoomCategoryResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] RoomCategoryDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        [HttpDelete("{id:long}")]
        [SwaggerOperation(Summary = "Delete a Room Category", Description = "Deletes a room category record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<RoomCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
        public override async Task<Response<RoomCategoryResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        [HttpDelete("bulk")]
        [SwaggerOperation(Summary = "Bulk delete Room Categories", Description = "Deletes multiple room category records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<RoomCategoryDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkDeleteAsync(entities, cancellationToken);
        }

        [HttpPut("bulk")]
        [SwaggerOperation(Summary = "Bulk update Room Categories", Description = "Updates multiple room category records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<RoomCategoryDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkUpdateAsync(entities, cancellationToken);
        }

        [HttpPost("bulk")]
        [SwaggerOperation(Summary = "Bulk add Room Categories", Description = "Adds multiple room category records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<RoomCategoryDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkAddAsync(entities, cancellationToken);
        }

        [HttpPatch("soft-delete/{id:long}")]
        [SwaggerOperation(Summary = "Soft delete a Room Category", Description = "Marks a room category record as deleted without removing it from the database.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<RoomCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<RoomCategoryResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.SoftDeleteAsync(id, cancellationToken);
        }
    }
}
