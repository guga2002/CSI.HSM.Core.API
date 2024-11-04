using AutoMapper;
using GuestSide.Application.DTOs.Request.Guest;
using GuestSide.Application.DTOs.Response.Guest;
using GuestSide.Application.Interface.Guest;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Guest
{
    public class GuestService:GenericService<GuestDto, GuestResponseDto,long,Guests>, IGuestService
    {
        public GuestService(
            [FromServices] IMapper mapper, 
            IGenericRepository<Guests> service, 
            [FromServices]ILogger<GenericService<GuestDto,GuestResponseDto, long, Guests>> logger) 
            : base(mapper, service, logger) { }


    }
}
