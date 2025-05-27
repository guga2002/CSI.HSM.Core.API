using Common.Data.Entities.Contacts;
using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Contacts;
using Core.Application.DTOs.Response.Contacts;
using Core.Application.Interface.GenericContracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Contacts;

[Route("api/[controller]")]
[ApiController]
public class ContactsStaffTypeController : CSIControllerBase<ContactsStaffTypeDto, ContactsStaffTypeResponseDto, long, ContactsStaffType>
{
    public ContactsStaffTypeController(
        IService<ContactsStaffTypeDto, ContactsStaffTypeResponseDto, long, ContactsStaffType> serviceProvider,
        IAdditionalFeatures<ContactsStaffTypeDto, ContactsStaffTypeResponseDto, long, ContactsStaffType> additionalFeatures)
        : base(serviceProvider, additionalFeatures)
    {
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Staff Types", Description = "Returns all staff type records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<ContactsStaffTypeResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<ContactsStaffTypeResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve Staff Type by ID", Description = "Fetches a specific staff type by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<ContactsStaffTypeResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<ContactsStaffTypeResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Staff Type", Description = "Adds a new staff type record.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<ContactsStaffTypeResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<ContactsStaffTypeResponseDto>> CreateAsync([FromBody] ContactsStaffTypeDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update Staff Type", Description = "Updates an existing staff type by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<ContactsStaffTypeResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<ContactsStaffTypeResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] ContactsStaffTypeDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete Staff Type", Description = "Deletes a staff type record by ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<ContactsStaffTypeResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<ContactsStaffTypeResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete Staff Types", Description = "Deletes multiple staff type records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<ContactsStaffTypeDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update Staff Types", Description = "Updates multiple staff type records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<ContactsStaffTypeDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add Staff Types", Description = "Adds multiple staff type records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<ContactsStaffTypeDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete Staff Type", Description = "Marks a staff type record as deleted without physically removing it.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<ContactsStaffTypeResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<ContactsStaffTypeResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
