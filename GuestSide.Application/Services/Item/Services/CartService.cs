using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Application.Interface.Item;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Item.Services;

public class CartService : GenericService<CartDto, CartResponseDto, long, Cart>, ICartService
{
    public CartService(IMapper mapper, 
        IGenericRepository<Cart> repository, 
        ILogger<GenericService<CartDto, CartResponseDto, long, Cart>> logger,
        IAdditioalFeatures<Cart> additioalFeatures) 
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
