using Core.API.CustomExtendControllerBase;
using Core.API.Response;
using Core.Application.DTOs.Request.Guest;
using Core.Application.DTOs.Response.Guest;
using Core.Application.Interface.Guest;
using Core.Application.Interface.GenericContracts;
using Core.Core.Entities.Guest;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Guest
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestActiveLanguageController : CSIControllerBase<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage>
    {
        private readonly IGuestActiveLanguageService _guestActiveLanguageService;

        public GuestActiveLanguageController(
            IGuestActiveLanguageService guestActiveLanguageService,
            IService<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage> serviceProvider,
            IAdditionalFeatures<GuestActiveLanguageDto, GuestActiveLanguageResponseDto, long, GuestActiveLanguage> additionalFeatures)
            : base(serviceProvider, additionalFeatures)
        {
            _guestActiveLanguageService = guestActiveLanguageService;
        }

        [HttpGet("guest/{guestId:long}")]
        [SwaggerOperation(Summary = "Get active language by guest ID", Description = "Retrieves the active language of a guest by their ID.")]
        [ProducesResponseType(typeof(Response<GuestActiveLanguageResponseDto>), StatusCodes.Status200OK)]
        public async Task<Response<GuestActiveLanguageResponseDto?>> GetActiveLanguageByGuestIdAsync([FromRoute] long guestId, CancellationToken cancellationToken = default)
        {
            var result = await _guestActiveLanguageService.GetActiveLanguageByGuestIdAsync(guestId, cancellationToken);
            return new Response<GuestActiveLanguageResponseDto?>(true, result);
        }

        [HttpGet("history/{guestId:long}")]
        [SwaggerOperation(Summary = "Get guest language history", Description = "Retrieves the history of languages used by a guest.")]
        [ProducesResponseType(typeof(Response<IEnumerable<GuestActiveLanguageResponseDto>>), StatusCodes.Status200OK)]
        public async Task<Response<IEnumerable<GuestActiveLanguageResponseDto>>> GetGuestLanguageHistoryAsync([FromRoute] long guestId, CancellationToken cancellationToken = default)
        {
            var result = await _guestActiveLanguageService.GetGuestLanguageHistoryAsync(guestId, cancellationToken);
            return new Response<IEnumerable<GuestActiveLanguageResponseDto>>(true, result);
        }

        [HttpPost("set-language/{guestId:long}")]
        [SwaggerOperation(Summary = "Set guest active language", Description = "Sets a new active language for a guest.")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> SetGuestActiveLanguageAsync([FromRoute] long guestId, [FromBody] string languageCode, CancellationToken cancellationToken = default)
        {
            var result = await _guestActiveLanguageService.SetGuestActiveLanguageAsync(guestId, languageCode, cancellationToken);
            return new Response<bool>(true, result);
        }

        [HttpDelete("remove-language/{guestId:long}")]
        [SwaggerOperation(Summary = "Remove guest active language", Description = "Removes the active language of a guest.")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> RemoveGuestActiveLanguageAsync([FromRoute] long guestId, CancellationToken cancellationToken = default)
        {
            var result = await _guestActiveLanguageService.RemoveGuestActiveLanguageAsync(guestId, cancellationToken);
            return new Response<bool>(true, result);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve all Guest Active Languages", Description = "Returns all guest active language records.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<GuestActiveLanguageResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
        public override async Task<Response<IEnumerable<GuestActiveLanguageResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Retrieve a Guest Active Language by ID", Description = "Fetches a specific guest active language record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<GuestActiveLanguageResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<GuestActiveLanguageResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new Guest Active Language record", Description = "Adds a new guest active language record to the system.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<GuestActiveLanguageResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<GuestActiveLanguageResponseDto>> CreateAsync([FromBody] GuestActiveLanguageDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Update an existing Guest Active Language record", Description = "Updates an existing guest active language record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<GuestActiveLanguageResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<GuestActiveLanguageResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] GuestActiveLanguageDto entityDto, CancellationToken cancellationToken = default)
        {
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Delete a Guest Active Language record", Description = "Deletes a guest active language record by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<GuestActiveLanguageResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found or failed to delete.")]
        public override async Task<Response<GuestActiveLanguageResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        [HttpDelete("bulk")]
        [SwaggerOperation(Summary = "Bulk delete Guest Active Language records", Description = "Deletes multiple guest active language records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<GuestActiveLanguageDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkDeleteAsync(entities, cancellationToken);
        }

        [HttpPut("bulk")]
        [SwaggerOperation(Summary = "Bulk update Guest Active Language records", Description = "Updates multiple guest active language records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<GuestActiveLanguageDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkUpdateAsync(entities, cancellationToken);
        }

        [HttpPost("bulk")]
        [SwaggerOperation(Summary = "Bulk add Guest Active Language records", Description = "Adds multiple guest active language records in a single operation.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
        public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<GuestActiveLanguageDto> entities, CancellationToken cancellationToken = default)
        {
            return await base.BulkAddAsync(entities, cancellationToken);
        }

        [HttpPatch("soft-delete/{id:int}")]
        [SwaggerOperation(Summary = "Soft delete a Guest Active Language record", Description = "Marks a guest active language record as deleted without removing it from the database.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<GuestActiveLanguageResponseDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
        public override async Task<Response<GuestActiveLanguageResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.SoftDeleteAsync(id, cancellationToken);
        }
    }
}
