﻿using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Application.Interface.Item;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Item.Services;

public class ItemService : GenericService<ItemDto, ItemResponseDto, long, Items>, IItemService
{
    public ItemService(IMapper mapper, 
        IGenericRepository<Items> repository, 
        ILogger<GenericService<ItemDto, ItemResponseDto, long, Items>> logger, 
        IAdditioalFeatures<Items> additioalFeatures) 
        : base(mapper, repository, logger, additioalFeatures)
    {
    }
}
