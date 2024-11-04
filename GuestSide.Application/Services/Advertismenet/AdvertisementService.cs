using AutoMapper;
using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Response.Advertisment;
using GuestSide.Application.Interface.Advertisment;
using GuestSide.Core.Entities.Advertisements;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Advertismenet
{
    public class AdvertisementService : GenericService<AdvertismentDto,AdvertismentResponseDto, long,Advertisements>, IAdvertismentService
    {
        public AdvertisementService(IGenericRepository<Advertisements> servic,IMapper map,ILogger<GenericService<AdvertismentDto,AdvertismentResponseDto, long, Advertisements>> loger) : base(map,servic, loger)
        {
        }
    }
}
