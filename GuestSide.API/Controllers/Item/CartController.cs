﻿using Common.Data.Entities.Item;
using Core.API.CustomExtendControllerBase;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.GenericContracts;
using Core.Application.Interface.Item;
using Generic.API.ResponseClass;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Core.API.Controllers.Item;

[Route("api/[controller]")]
[ApiController]
public class CartController : CSIControllerBase<CartDto, CartResponseDto, long, Cart>
{
    private readonly ICartService _cartService;

    public CartController(
        IService<CartDto, CartResponseDto, long, Cart> serviceProvider,
        IAdditionalFeatures<CartDto, CartResponseDto, long, Cart> additionalFeatures,
        ICartService cartService)
        : base(serviceProvider, additionalFeatures)
    {
        _cartService = cartService;
    }

    [HttpGet("latest-active-cart/{guestId:long}")]
    [SwaggerOperation(Summary = "Get latest active cart for a guest", Description = "Returns the latest active cart for a guest.")]
    [SwaggerResponse(StatusCodes.Status200OK, "Record retrieved successfully.", typeof(Response<CartResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No active cart found.")]
    public async Task<Response<CartResponseDto?>> GetLatestActiveCartForGuestAsync([FromRoute] long guestId, CancellationToken cancellationToken = default)
    {
        var result = await _cartService.GetLatestActiveCartForGuestAsync(guestId, cancellationToken);
        return new Response<CartResponseDto?>(result is not null ? true : false, result);
    }

    [HttpDelete("clearCart/{cartId:long}")]
    [SwaggerOperation(Summary = "Clear current cart", Description = "return boolean if  cart clear")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(bool))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public async Task<Response<bool>> ClearCart(long cartId)
    {
        var res = await _cartService.ClearCart(cartId);

        if (res)
        {
            return Response<bool>.SuccessResponse(true);
        }

        return Response<bool>.ErrorResponse("Error while clear  cart");
    }

    [HttpGet("cartsummary/{cartId:long}")]
    [SwaggerOperation(Summary = "Get cart Summary", Description = "Return  cart which is cleared!")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<CartResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public async Task<Response<CartResponseDto>> CartSymmary(long cartId)
    {
        var res = await _cartService.CartSummary(cartId);

        if (res is not null)
        {
            return Response<CartResponseDto>.SuccessResponse(res);
        }

        return Response<CartResponseDto>.ErrorResponse("No data found");
    }



    [HttpDelete("RemoveItemFromCart/{cartId:long}/{itemId:long}")]
    [SwaggerOperation(Summary = "Remove item from cart", Description = "return updated cart")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<CartResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public async Task<Response<CartResponseDto>> RemoveItemFromCart(long cartId, long itemId)
    {
        var res = await _cartService.RemoveItemFromCart(cartId, itemId);

        if (res is not null)
        {
            return Response<CartResponseDto>.SuccessResponse(res);
        }

        return Response<CartResponseDto>.ErrorResponse("No data found");
    }

    [HttpGet("GetCartByGuestId/{guestId:long}")]
    [SwaggerOperation(Summary = "Get Carts For Guest Id", Description = "return carts for guest by status")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<IEnumerable<CartResponseDto>>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public async Task<Response<IEnumerable<CartResponseDto>>> GetCartsByGuestId(long guestId, bool status)
    {
        var res = await _cartService.GetCartByGuestId(guestId, status);

        if (res is not null)
        {
            return Response<IEnumerable<CartResponseDto>>.SuccessResponse(res);
        }

        return Response<IEnumerable<CartResponseDto>>.ErrorResponse("No data found");
    }

    [HttpGet("UpdateItemQuantityInCart/{cartId:long}/{itemId:long}/{newQuantity:int}")]
    [SwaggerOperation(Summary = "Update Item Quantity In Cart", Description = "return Cart Response Dto")]
    [SwaggerResponse(StatusCodes.Status200OK, "Records retrieved successfully.", typeof(Response<CartResponseDto>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No records found.")]
    public async Task<Response<CartResponseDto>> UpdateItemQuantityInCart(long cartId, long itemId, int newQuantity)
    {
        var res = await _cartService.UpdateItemQuantityInCart(cartId, itemId, newQuantity);

        if (res is not null)
        {
            return Response<CartResponseDto>.SuccessResponse(res);
        }

        return Response<CartResponseDto>.ErrorResponse("No data found");
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
