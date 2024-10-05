using AutoMapper;
using GuestSide.Application.DTOs.Item;
using GuestSide.Application.Interface.Item;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Item.Services
{
    public class ItemService:GenericService<ItemDto,long,Items>,IItemService
    {
        public ItemService(IMapper mapper, 
            IGenericRepository<Items> repos, 
            ILogger<GenericService<ItemDto,long,Items>> logger)
            :base(mapper,repos,logger)
        {
        }
    }
}
