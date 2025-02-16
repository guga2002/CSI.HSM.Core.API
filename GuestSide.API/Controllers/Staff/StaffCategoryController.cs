using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Staff;
using Core.Application.DTOs.Response.Staff;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Staff.Category;
using Core.Core.Entities.Staff;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffCategoryController : CSIControllerBase<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory>
    {
        private readonly IStaffCategoryService _staffCategoryService;

        public StaffCategoryController(
            IStaffCategoryService staffCategoryService,
            IService<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory> serviceProvider,
            IAdditionalFeatures<StaffCategoryDto, StaffCategoryResponseDto, long, StaffCategory> additionalFeatures)
            : base(serviceProvider, additionalFeatures)
        {
            _staffCategoryService = staffCategoryService;
        }

        [HttpGet("by-name")]
        [SwaggerOperation(Summary = "Retrieve Staff Category by Name", Description = "Fetches staff category details by its name.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Category retrieved successfully.", typeof(Response<StaffCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Category not found.")]
        public async Task<Response<StaffCategoryResponseDto>> GetByCategoryNameAsync([FromQuery] string categoryName)
        {
            var result = await _staffCategoryService.GetByCategoryNameAsync(categoryName);
            return result != null
                ? Response<StaffCategoryResponseDto>.SuccessResponse(result)
                : Response<StaffCategoryResponseDto>.ErrorResponse("Category not found.");
        }

        [HttpGet("active")]
        [SwaggerOperation(Summary = "Retrieve Active Staff Categories", Description = "Fetches all active staff categories.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Active categories retrieved successfully.", typeof(Response<IEnumerable<StaffCategoryResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No active categories found.")]
        public async Task<Response<IEnumerable<StaffCategoryResponseDto>>> GetActiveCategoriesAsync()
        {
            var result = await _staffCategoryService.GetActiveCategoriesAsync();
            return result.Any()
                ? Response<IEnumerable<StaffCategoryResponseDto>>.SuccessResponse(result)
                : Response<IEnumerable<StaffCategoryResponseDto>>.ErrorResponse("No active categories found.");
        }

        [HttpGet("inactive")]
        [SwaggerOperation(Summary = "Retrieve Inactive Staff Categories", Description = "Fetches all inactive staff categories.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Inactive categories retrieved successfully.", typeof(Response<IEnumerable<StaffCategoryResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No inactive categories found.")]
        public async Task<Response<IEnumerable<StaffCategoryResponseDto>>> GetInactiveCategoriesAsync()
        {
            var result = await _staffCategoryService.GetInactiveCategoriesAsync();
            return result.Any()
                ? Response<IEnumerable<StaffCategoryResponseDto>>.SuccessResponse(result)
                : Response<IEnumerable<StaffCategoryResponseDto>>.ErrorResponse("No inactive categories found.");
        }

        [HttpGet("between-dates")]
        [SwaggerOperation(Summary = "Retrieve Staff Categories Created Between Two Dates", Description = "Fetches staff categories created between specific start and end dates.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Categories retrieved successfully.", typeof(Response<IEnumerable<StaffCategoryResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No categories found.")]
        public async Task<Response<IEnumerable<StaffCategoryResponseDto>>> GetCategoriesCreatedBetweenDatesAsync(
            [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = await _staffCategoryService.GetCategoriesCreatedBetweenDatesAsync(startDate, endDate);
            return result.Any()
                ? Response<IEnumerable<StaffCategoryResponseDto>>.SuccessResponse(result)
                : Response<IEnumerable<StaffCategoryResponseDto>>.ErrorResponse("No categories found.");
        }

        [HttpPatch("update-name/{categoryId:long}")]
        [SwaggerOperation(Summary = "Update Staff Category Name", Description = "Updates the name of a specific staff category.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Category name updated successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Category not found.")]
        public async Task<Response<bool>> UpdateCategoryNameAsync([FromRoute] long categoryId, [FromBody] string newName)
        {
            var result = await _staffCategoryService.UpdateCategoryNameAsync(categoryId, newName);
            return result
                ? Response<bool>.SuccessResponse(true, "Category name updated successfully.")
                : Response<bool>.ErrorResponse("Category not found.");
        }

        [HttpPatch("update-description/{categoryId:long}")]
        [SwaggerOperation(Summary = "Update Staff Category Description", Description = "Updates the description of a specific staff category.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Category description updated successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Category not found.")]
        public async Task<Response<bool>> UpdateCategoryDescriptionAsync([FromRoute] long categoryId, [FromBody] string newDescription)
        {
            var result = await _staffCategoryService.UpdateCategoryDescriptionAsync(categoryId, newDescription);
            return result
                ? Response<bool>.SuccessResponse(true, "Category description updated successfully.")
                : Response<bool>.ErrorResponse("Category not found.");
        }

        [HttpGet("is-assigned/{categoryId:long}")]
        [SwaggerOperation(Summary = "Check if Category is Assigned to Staff", Description = "Checks if a specific staff category is assigned to any staff members.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Check completed successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Category not found.")]
        public async Task<Response<bool>> IsCategoryAssignedToStaffAsync([FromRoute] long categoryId)
        {
            var result = await _staffCategoryService.IsCategoryAssignedToStaffAsync(categoryId);
            return Response<bool>.SuccessResponse(result);
        }

        //[HttpGet("staffs/{categoryId:long}")]
        //[SwaggerOperation(Summary = "Retrieve Staff Assigned to Category", Description = "Fetches all staff members assigned to a specific category.")]
        //[SwaggerResponse(StatusCodes.Status200OK, "Staff members retrieved successfully.", typeof(Response<IEnumerable<Staffs>>))]
        //[SwaggerResponse(StatusCodes.Status404NotFound, "No staff members found.")]
        //public async Task<Response<IEnumerable<Staffs>>> GetStaffByCategoryIdAsync([FromRoute] long categoryId)
        //{
        //    var result = await _staffCategoryService.GetStaffByCategoryIdAsync(categoryId);
        //    return result.Any()
        //        ? Response<IEnumerable<Staffs>>.SuccessResponse(result)
        //        : Response<IEnumerable<Staffs>>.ErrorResponse("No staff members found.");
        //}

        //[HttpGet("tasks/{categoryId:long}")]
        //[SwaggerOperation(Summary = "Retrieve Tasks Associated with Category", Description = "Fetches all tasks associated with a specific category.")]
        //[SwaggerResponse(StatusCodes.Status200OK, "Tasks retrieved successfully.", typeof(Response<IEnumerable<TaskToStaff>>))]
        //[SwaggerResponse(StatusCodes.Status404NotFound, "No tasks found.")]
        //public async Task<Response<IEnumerable<TaskToStaff>>> GetTasksByCategoryIdAsync([FromRoute] long categoryId)
        //{
        //    var result = await _staffCategoryService.GetTasksByCategoryIdAsync(categoryId);
        //    return result.Any()
        //        ? Response<IEnumerable<TaskToStaff>>.SuccessResponse(result)
        //        : Response<IEnumerable<TaskToStaff>>.ErrorResponse("No tasks found.");
        //}

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all Staff Categories", Description = "Returns all staff category records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<StaffCategoryResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<StaffCategoryResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:long}")]
        [SwaggerOperation(Summary = "Retrieve a Staff Category by ID", Description = "Fetches a specific staff category record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<StaffCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<StaffCategoryResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Staff Category", Description = "Adds a new staff category record to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<StaffCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<StaffCategoryResponseDto>> CreateAsync([FromBody] StaffCategoryDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpPut("{id:long}")]
        [SwaggerOperation(Summary = "Update an existing Staff Category", Description = "Updates an existing staff category record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<StaffCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<StaffCategoryResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] StaffCategoryDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        [HttpDelete("{id:long}")]
        [SwaggerOperation(Summary = "Delete a Staff Category", Description = "Deletes a staff category record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<StaffCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
        public override async Task<Response<StaffCategoryResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        [HttpDelete("bulk")]
        [SwaggerOperation(Summary = "Bulk delete Staff Categories", Description = "Deletes multiple staff category records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<StaffCategoryDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkDeleteAsync(entities, cancellationToken);
        }

        [HttpPut("bulk")]
        [SwaggerOperation(Summary = "Bulk update Staff Categories", Description = "Updates multiple staff category records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<StaffCategoryDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkUpdateAsync(entities, cancellationToken);
        }

        [HttpPost("bulk")]
        [SwaggerOperation(Summary = "Bulk add Staff Categories", Description = "Adds multiple staff category records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<StaffCategoryDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkAddAsync(entities, cancellationToken);
        }

        [HttpPatch("soft-delete/{id:long}")]
        [SwaggerOperation(Summary = "Soft delete a Staff Category", Description = "Marks a staff category record as deleted without removing it from the database.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<StaffCategoryResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<StaffCategoryResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.SoftDeleteAsync(id, cancellationToken);
        }
    }
}
