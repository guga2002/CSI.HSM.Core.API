using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Advertisment;
using Core.Application.DTOs.Response.Advertisment;
using Core.Application.Interface.AdvertiementType;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Advertisements;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Advertisement
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvertisemenetTypeController : CSIControllerBase<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType>
    {
        private readonly IAdvertisementTypeService _advertisementTypeService;

        public AdvertisemenetTypeController(
            IAdvertisementTypeService advertisementTypeService,
            IService<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType> serviceProvider,
            IAdditionalFeatures<AdvertisementTypeDto, AdvertisementTypeResponseDto, long, AdvertisementType> additionalFeatures)
            : base(serviceProvider, additionalFeatures)
        {
            _advertisementTypeService = advertisementTypeService;
        }

        [HttpGet("by-name/{name}")]
        [SwaggerOperation(Summary = "Get advertisement type by name", Description = "Fetches an advertisement type by its name.")]
        [ProducesResponseType(typeof(Response<AdvertisementTypeResponseDto>), StatusCodes.Status200OK)]
        public async Task<Response<AdvertisementTypeResponseDto?>> GetAdvertisementTypeByNameAsync([FromRoute] string name, CancellationToken cancellationToken = default)
        {
            var result = await _advertisementTypeService.GetAdvertisementTypeByNameAsync(name, cancellationToken);
            return new Response<AdvertisementTypeResponseDto?>(true, result);
        }

        [HttpGet("all")]
        [SwaggerOperation(Summary = "Get all advertisement types", Description = "Retrieves all advertisement types.")]
        [ProducesResponseType(typeof(Response<IEnumerable<AdvertisementTypeResponseDto>>), StatusCodes.Status200OK)]
        public async Task<Response<IEnumerable<AdvertisementTypeResponseDto>>> GetAllAdvertisementTypesAsync(CancellationToken cancellationToken = default)
        {
            var result = await _advertisementTypeService.GetAllAdvertisementTypesAsync(cancellationToken);
            return new Response<IEnumerable<AdvertisementTypeResponseDto>>(true,result);
        }

        [HttpGet("by-language/{languageCode}")]
        [SwaggerOperation(Summary = "Get advertisement types by language", Description = "Retrieves advertisement types based on the specified language.")]
        [ProducesResponseType(typeof(Response<IEnumerable<AdvertisementTypeResponseDto>>), StatusCodes.Status200OK)]
        public async Task<Response<IEnumerable<AdvertisementTypeResponseDto>>> GetAdvertisementTypesByLanguageAsync([FromRoute] string languageCode, CancellationToken cancellationToken = default)
        {
            var result = await _advertisementTypeService.GetAdvertisementTypesByLanguageAsync(languageCode, cancellationToken);
            return new Response<IEnumerable<AdvertisementTypeResponseDto>>(true, result);
        }

        [HttpPut("update-description/{id}")]
        [SwaggerOperation(Summary = "Update advertisement type description", Description = "Updates the description of an advertisement type.")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> UpdateAdvertisementTypeDescriptionAsync([FromRoute] long id, [FromBody] string newDescription, CancellationToken cancellationToken = default)
        {
            var result = await _advertisementTypeService.UpdateAdvertisementTypeDescriptionAsync(id, newDescription, cancellationToken);
            return new Response<bool>(true,result);
        }

        [HttpDelete("delete/{id}")]
        [SwaggerOperation(Summary = "Delete advertisement type by ID", Description = "Deletes a specific advertisement type by its ID.")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> DeleteAdvertisementTypeByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            var result = await _advertisementTypeService.DeleteAdvertisementTypeByIdAsync(id, cancellationToken);
            return new Response<bool>(true, result);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all Advertisement Types", Description = "Returns all advertisement type records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<AdvertisementTypeResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<AdvertisementTypeResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:long}")]
        [SwaggerOperation(Summary = "Retrieve an Advertisement Type by ID", Description = "Fetches a specific advertisement type record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<AdvertisementTypeResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<AdvertisementTypeResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Advertisement Type", Description = "Adds a new advertisement type record to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<AdvertisementTypeResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<AdvertisementTypeResponseDto>> CreateAsync([FromBody] AdvertisementTypeDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpPut("{id:long}")]
        [SwaggerOperation(Summary = "Update an existing Advertisement Type", Description = "Updates an existing advertisement type record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<AdvertisementTypeResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<AdvertisementTypeResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] AdvertisementTypeDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        [HttpDelete("{id:long}")]
        [SwaggerOperation(Summary = "Delete an Advertisement Type", Description = "Deletes an advertisement type record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<AdvertisementTypeResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<AdvertisementTypeResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        [HttpDelete("bulk")]
        [SwaggerOperation(Summary = "Bulk delete Advertisement Types", Description = "Deletes multiple advertisement type records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<AdvertisementTypeDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkDeleteAsync(entities, cancellationToken);
        }

        [HttpPut("bulk")]
        [SwaggerOperation(Summary = "Bulk update Advertisement Types", Description = "Updates multiple advertisement type records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<AdvertisementTypeDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkUpdateAsync(entities, cancellationToken);
        }

        [HttpPost("bulk")]
        [SwaggerOperation(Summary = "Bulk add Advertisement Types", Description = "Adds multiple advertisement type records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<AdvertisementTypeDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkAddAsync(entities, cancellationToken);
        }

        [HttpPatch("soft-delete/{id:long}")]
        [SwaggerOperation(Summary = "Soft delete an Advertisement Type", Description = "Marks an advertisement type record as deleted without removing it from the database.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<AdvertisementTypeResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<AdvertisementTypeResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.SoftDeleteAsync(id, cancellationToken);
        }
    }
}
