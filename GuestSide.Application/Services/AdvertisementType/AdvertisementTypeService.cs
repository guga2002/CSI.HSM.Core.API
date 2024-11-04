using AutoMapper;
using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;
using GuestSide.Application.Interface.AdvertiementType;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.AdvertisementType
{
    public class AdvertisementTypeService : GenericService<AdvertisementTypeDto,AdvertisementTypeResponseDto, long, GuestSide.Core.Entities.Advertisments.AdvertisementType>, IAdvertisementTypeService
    {
        public AdvertisementTypeService(
            IGenericRepository<GuestSide.Core.Entities.Advertisments.AdvertisementType> servic,IMapper map,ILogger<GenericService<AdvertisementTypeDto,AdvertisementTypeResponseDto, long, GuestSide.Core.Entities.Advertisments.AdvertisementType>>log) : base(map,servic,log)
        {
        }
    }
}
