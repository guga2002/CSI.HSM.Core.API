using AutoMapper;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Application.Interface.Item;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Item.Services
{
    public class ItemCategoryService:GenericService<ItemCategoryDto,ItemCategoryResponseDto,long,ItemCategory>,IItemCategoryService
    {
        public ItemCategoryService(IMapper mapper, 
            IGenericRepository<ItemCategory> repos, 
            ILogger<GenericService<ItemCategoryDto,ItemCategoryResponseDto, long,ItemCategory>> logger)
            :base(mapper,repos,logger)
        {
        }
    }
}
