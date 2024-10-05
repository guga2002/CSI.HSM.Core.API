using AutoMapper;
using GuestSide.Application.DTOs.Item;
using GuestSide.Application.Interface.Item;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Item.Services
{
    public class CartService:GenericService<CartDto,long,Cart>, ICartService
    {
        public CartService(IMapper mapper,
            IGenericRepository<Cart>rep,
            ILogger<GenericService<CartDto,long,Cart>>logger )
            :base(mapper,rep,logger)
        {
        }
    }
}
