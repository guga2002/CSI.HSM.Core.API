using Common.Data.Entities.Language;
using Core.API.CustomExtendControllerBase;
using Core.Application.DTOs.Request.Language;
using Core.Application.DTOs.Response.Language;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Language;
using Generic.API.ResponseClass;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Language;

[Route("api/[controller]")]
[ApiController]
public class LanguageController : CSIControllerBase<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack>
{
    private readonly ILanguageService _languageService;

    public LanguageController(
        IService<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack> serviceProvider,
        IAdditionalFeatures<LanguagePackDto, LanguagePackResponseDto, long, LanguagePack> additionalFeatures,
        ILanguageService languageService)
        : base(serviceProvider, additionalFeatures)
    {
        _languageService = languageService;
    }

    [HttpGet("active")]
    [SwaggerOperation(Summary = "Retrieve all Active Language Packs", Description = "Fetches all active language packs.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<LanguagePackResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No active language packs found.")]
    public async Task<Response<IEnumerable<LanguagePackResponseDto>>> GetAllActiveLanguagesAsync(CancellationToken cancellationToken = default)
    {
        var result = await _languageService.GetAllActiveLanguages(cancellationToken);
        return result.Any() ? Response<IEnumerable<LanguagePackResponseDto>>.SuccessResponse(result)
            : Response<IEnumerable<LanguagePackResponseDto>>.ErrorResponse("No active language packs found.");
    }

    [HttpGet("by-code/{code}")]
    [SwaggerOperation(Summary = "Retrieve Language Pack by Code", Description = "Fetches a specific language pack based on its unique language code.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<LanguagePackResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Language pack not found.")]
    public async Task<Response<LanguagePackResponseDto>> GetLanguageByCodeAsync([FromRoute] string code, CancellationToken cancellationToken = default)
    {
        var result = await _languageService.GetLanguageByCode(code, cancellationToken);
        return result is not null ? Response<LanguagePackResponseDto>.SuccessResponse(result)
            : Response<LanguagePackResponseDto>.ErrorResponse("Language pack not found.");
    }

    [HttpPatch("soft-delete/{languageId:long}")]
    [SwaggerOperation(Summary = "Soft Delete a Language Pack", Description = "Marks a language pack as inactive instead of removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Language pack soft deleted successfully.", typeof(Response<bool>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Language pack not found.")]
    public async Task<Response<bool>> SoftDeleteLanguageAsync([FromRoute] long languageId, CancellationToken cancellationToken = default)
    {
        var result = await _languageService.SoftDeleteLanguage(languageId, cancellationToken);
        return result ? Response<bool>.SuccessResponse(true, "Language pack soft deleted successfully.")
            : Response<bool>.ErrorResponse("Failed to soft delete language pack.");
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Retrieve all Language Packs", Description = "Returns all language pack records.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<LanguagePackResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public override async Task<Response<IEnumerable<LanguagePackResponseDto>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await base.GetAllAsync(cancellationToken);
    }

    [HttpGet("{id:long}")]
    [SwaggerOperation(Summary = "Retrieve a Language Pack by ID", Description = "Fetches a specific language pack record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<LanguagePackResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<LanguagePackResponseDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Language Pack", Description = "Adds a new language pack record to the system.")]
    [SwaggerResponse(StatusCodes.Status201Created, "Record created successfully.", typeof(Response<LanguagePackResponseDto>))]
    [SwaggerResponse(StatusCodes.Status200OK, "Record created successfully.", typeof(Response<LanguagePackResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<LanguagePackResponseDto>> CreateAsync([FromBody] LanguagePackDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.CreateAsync(entityDto, cancellationToken);
    }

    [HttpPut("{id:long}")]
    [SwaggerOperation(Summary = "Update an existing Language Pack", Description = "Updates an existing language pack record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record updated successfully.", typeof(Response<LanguagePackResponseDto>))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public override async Task<Response<LanguagePackResponseDto>> UpdateAsync([FromRoute] long id, [FromBody] LanguagePackDto entityDto, CancellationToken cancellationToken = default)
    {
        return await base.UpdateAsync(id, entityDto, cancellationToken);
    }

    [HttpDelete("{id:long}")]
    [SwaggerOperation(Summary = "Delete a Language Pack", Description = "Deletes a language pack record by its ID.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record deleted successfully.", typeof(Response<LanguagePackResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<LanguagePackResponseDto>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.DeleteAsync(id, cancellationToken);
    }

    [HttpDelete("bulk")]
    [SwaggerOperation(Summary = "Bulk delete Language Packs", Description = "Deletes multiple language pack records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities deleted successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkDeleteAsync([FromBody] IEnumerable<LanguagePackDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkDeleteAsync(entities, cancellationToken);
    }

    [HttpPut("bulk")]
    [SwaggerOperation(Summary = "Bulk update Language Packs", Description = "Updates multiple language pack records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities updated successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkUpdateAsync([FromBody] IEnumerable<LanguagePackDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkUpdateAsync(entities, cancellationToken);
    }

    [HttpPost("bulk")]
    [SwaggerOperation(Summary = "Bulk add Language Packs", Description = "Adds multiple language pack records in a single operation.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Entities added successfully.", typeof(IActionResult))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data. Collection is empty or null.")]
    public override async Task<IActionResult> BulkAddAsync([FromBody] IEnumerable<LanguagePackDto> entities, CancellationToken cancellationToken = default)
    {
        return await base.BulkAddAsync(entities, cancellationToken);
    }

    [HttpPatch("soft-delete/{id:long}")]
    [SwaggerOperation(Summary = "Soft delete a Language Pack", Description = "Marks a language pack record as deleted without removing it from the database.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record soft deleted successfully.", typeof(Response<LanguagePackResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Record not found.")]
    public override async Task<Response<LanguagePackResponseDto>> SoftDeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
    {
        return await base.SoftDeleteAsync(id, cancellationToken);
    }
}
