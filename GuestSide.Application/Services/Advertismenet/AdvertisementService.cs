using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Application.Interface.Advertisment;
using GuestSide.Core.Interfaces.AbstractInterface;

namespace GuestSide.Application.Services.Advertismenet
{
    public class AdvertisementService : GenericService<AdvertismentDto, long>, IAdvertismentService
    {
        public AdvertisementService(IGenericRepository<AdvertismentDto> servic) : base(servic)
        {
        }
    }
}
