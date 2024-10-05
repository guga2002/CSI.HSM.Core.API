using AutoMapper;
using GuestSide.Application.DTOs.NewFolder;
using GuestSide.Application.Interface.Guest;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Interfaces.AbstractInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Guest
{
    public class GuestService:GenericService<GuestDto,long,Guests>, IGuestService
    {
        public GuestService(
            [FromServices] IMapper mapper, 
            IGenericRepository<Guests> service, 
            [FromServices]ILogger<GenericService<GuestDto, long, Guests>> logger) 
            : base(mapper, service, logger) { }


    }
}
