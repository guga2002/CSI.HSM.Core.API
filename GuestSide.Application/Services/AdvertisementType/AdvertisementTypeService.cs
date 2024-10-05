using AutoMapper;
using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Application.Interface.AdvertiementType;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestSide.Application.Services.AdvertisementType
{
    public class AdvertisementTypeService : GenericService<AdvertisementTypeDto, long, GuestSide.Core.Entities.Advertisments.AdvertisementType>, IAdvertisementTypeService
    {
        public AdvertisementTypeService(
            IGenericRepository<GuestSide.Core.Entities.Advertisments.AdvertisementType> servic,IMapper map,ILogger<GenericService<AdvertisementTypeDto, long, GuestSide.Core.Entities.Advertisments.AdvertisementType>>log) : base(map,servic,log)
        {
        }
    }
}
