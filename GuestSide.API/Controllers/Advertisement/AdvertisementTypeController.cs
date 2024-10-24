using GuestSide.API.CustomExtendControllerBase;
using GuestSide.API.Response;
using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Advertisments;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GuestSide.API.Controllers.Advertisement
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementTypeController : CSIControllerBase<AdvertisementTypeDto, long, AdvertisementType>
    {
        public AdvertisementTypeController(IService<AdvertisementTypeDto, long, AdvertisementType> serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Retrieves all advertisement types.
        /// </summary>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A list of all advertisement types.</returns>
        [HttpGet("GetAdvertisementTypes")]
        [SwaggerOperation(Summary = "Retrieve all advertisement types", Description = "Returns a list of all advertisement types.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved advertisement types.", typeof(Response<IEnumerable<AdvertisementTypeDto>>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No advertisement types found.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "No content found for advertisement")]
        public override async Task<Response<IEnumerable<AdvertisementTypeDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific advertisement type by its ID.
        /// </summary>
        /// <param name="id">The ID of the advertisement type.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The advertisement type matching the specified ID.</returns>
        [HttpGet("GetAdvertisementTypeById/{id}")]
        [SwaggerOperation(Summary = "Retrieve advertisement type by ID", Description = "Returns a specific advertisement type by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Successfully retrieved the advertisement type.", typeof(Response<AdvertisementTypeDto>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Advertisement type not found.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "No content found for advertisement")]
        public override async Task<Response<AdvertisementTypeDto>> GetByIdAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Creates a new advertisement type.
        /// </summary>
        /// <param name="entityDto">The advertisement type to create.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The created advertisement type.</returns>
        [HttpPost("CreateAdvertisementType")]
        [SwaggerOperation(Summary = "Create a new advertisement type", Description = "Creates a new advertisement type.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Advertisement type created successfully.", typeof(Response<AdvertisementTypeDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<AdvertisementTypeDto>> CreateAsync([FromBody] AdvertisementTypeDto entityDto, CancellationToken cancellationToken = default)
        {
            // Custom validation can be added here if needed
            if (entityDto == null || string.IsNullOrWhiteSpace(entityDto.Description))
            {
                return Response<AdvertisementTypeDto>.ErrorResponse("Invalid input data.", 400);
            }
            return await base.CreateAsync(entityDto, cancellationToken);
        }

        /// <summary>
        /// Updates an existing advertisement type.
        /// </summary>
        /// <param name="id">The ID of the advertisement type to update.</param>
        /// <param name="entityDto">The updated advertisement type data.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>The updated advertisement type.</returns>
        [HttpPut("UpdateAdvertisementType/{id}")]
        [SwaggerOperation(Summary = "Update an existing advertisement type", Description = "Updates the advertisement type with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Advertisement type updated successfully.", typeof(Response<AdvertisementTypeDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
        public override async Task<Response<AdvertisementTypeDto>> UpdateAsync([FromRoute] long id, [FromBody] AdvertisementTypeDto entityDto, CancellationToken cancellationToken = default)
        {
            // Custom validation can be added here if needed
            if (entityDto == null || string.IsNullOrWhiteSpace(entityDto.Description))
            {
                return Response<AdvertisementTypeDto>.ErrorResponse("Invalid input data.", 400);
            }
            return await base.UpdateAsync(id, entityDto, cancellationToken);
        }

        /// <summary>
        /// Deletes an advertisement type by its ID.
        /// </summary>
        /// <param name="id">The ID of the advertisement type to delete.</param>
        /// <param name="cancellationToken">Token to cancel the request.</param>
        /// <returns>A success or failure response.</returns>
        [HttpDelete("DeleteAdvertisementType/{id}")]
        [SwaggerOperation(Summary = "Delete an advertisement type", Description = "Deletes the advertisement type with the specified ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Advertisement type deleted successfully.", typeof(Response<bool>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Advertisement type not found or failed to delete.")]
        public override async Task<Response<bool>> DeleteAsync([FromRoute] long id, CancellationToken cancellationToken = default)
        {
            return await base.DeleteAsync(id, cancellationToken);
        }

        // Add more methods or features as needed.
    }
}
