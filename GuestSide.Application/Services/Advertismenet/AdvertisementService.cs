using AutoMapper;
using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Application.Interface.Advertisment;
using GuestSide.Core.Entities.Advertisements;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Advertismenet
{
    public class AdvertisementService : GenericService<AdvertismentDto, long,Advertisements>, IAdvertismentService
    {
        public AdvertisementService(IGenericRepository<Advertisements> servic,IMapper map,ILogger<GenericService<AdvertismentDto, long, Advertisements>> loger) : base(map,servic, loger)
        {
        }
    }
}
